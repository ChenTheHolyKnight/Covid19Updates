import React,{Component} from 'react'
import {Card, CardDeck, Form, FormControl, Button, Table, FormGroup} from "react-bootstrap";
import CanvasJSReact from "../canvasjs.react";
import {SingleDataService} from "../../service/SingleDataService";

var CanvasJSChart = CanvasJSReact.CanvasJSChart;


export default class WorldDataBottomRow extends Component{

    constructor(props){
        super(props)
        this.state={
            globalData:{
                NewConfirmed: Number,
                TotalConfirmed: Number,
                NewDeaths: Number,
                TotalDeaths: Number,
                NewRecovered: Number,
                TotalRecovered: Number
            },
            countryData: [],
            selectedCountry: {
                TotalConfirmed: Number,
                TotalRecovered: Number,
                TotalDeaths: Number
            },
            selectedCountryName: String
        }

        this.handleFormSubmit = this.handleFormSubmit.bind(this);
    }

    findArrayElementByCountry(array, country) {
        return array.find((element) => {
            return element.Country === country;
        })
    }

    async componentWillMount() {
        const service = new SingleDataService()
        let response = await service.getWorldData()
        const selectedData = this.findArrayElementByCountry(response.Countries,'New Zealand')
        this.setState({
            globalData:    response.Global,
            countryData: response.Countries,
            selectedCountry: selectedData
        })


    }

    handleChange(event){
        event.preventDefault()
        this.setState({
            selectedCountryName: event.target.value
        })
        console.log("Changes")
    }

     handleFormSubmit = (event)=>{
        console.log("Fuck")
        const selectedData = this.findArrayElementByCountry(this.state.countryData,this.selectedCountryName)
        this.setState({
            selectedCountry: selectedData,
            selectedCountryName: 'Selected'
        })
    }


    render() {
        const confirmed = this.state.selectedCountry.TotalConfirmed
        const recovered = this.state.selectedCountry.TotalRecovered
        const death = this.state.selectedCountry.TotalDeaths
        const other = confirmed-recovered-death

        const options = {
            exportEnabled: false,
            animationEnabled: true,
            data: [{
                type: "pie",
                startAngle: 75,
                toolTipContent: "<b>{label}</b>: {y}%",
                showInLegend: "true",
                legendText: "{label}",
                indexLabelFontSize: 16,
                indexLabel: "{label}: {y}%",
                dataPoints: [
                    { y: Math.round(recovered/confirmed*100).toFixed(2), label: "Recovered Cases" },
                    { y: Math.round(death/confirmed*100).toFixed(2), label: "Death" },
                    { y: Math.round(other/confirmed*100).toFixed(2),label: "Other"}
                ]
            }]
        }



        return <CardDeck style={{marginTop:"2vh"}}>
            <Card>
                <Card.Body>
                    <Card.Title>
                        <Form inline onSubmit={this.handleFormSubmit = this.handleFormSubmit.bind(this)} style={{display: "flex",justifyContent: "flex-end"}}>
                            <FormGroup>
                                <FormControl type="text" placeholder="Search" className="mr-sm-2" onChange={this.handleChange = this.handleChange.bind(this)}/>
                            </FormGroup>
                            <Button variant="dark">Search</Button>
                        </Form>
                    </Card.Title>

                    <CardDeck>
                        <Card>
                            <Card.Title style={{marginTop:"3vh",marginLeft:"3vh"}}> Summary</Card.Title>
                            <Card.Body>
                                <Table style={{marginTop: '10vh'}}>
                                    <thead>
                                    <tr>
                                        <th>Categories</th>
                                        <th>Total</th>
                                    </tr>
                                    </thead>
                                    <tbody>
                                    <tr>
                                        <td>Confirmed Cases</td>
                                        <td>{this.state.selectedCountry.TotalConfirmed}</td>
                                    </tr>
                                    <tr>
                                        <td>Recovered Cases</td>
                                        <td>{this.state.selectedCountry.TotalRecovered}</td>
                                    </tr>
                                    <tr>
                                        <td>Death</td>
                                        <td>{this.state.selectedCountry.TotalDeaths}</td>
                                    </tr>
                                    </tbody>
                                </Table>
                            </Card.Body>
                        </Card>
                        <Card>
                            <Card.Title style={{marginTop:"3vh",marginLeft:"3vh"}}> Death vs Recovery</Card.Title>
                            <Card.Body>
                                <CanvasJSChart options = {options}/>
                            </Card.Body>
                        </Card>
                    </CardDeck>


                </Card.Body>
            </Card>
        </CardDeck>
    }
}
