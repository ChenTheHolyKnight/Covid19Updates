import React,{Component} from 'react'
import {Card, CardDeck} from "react-bootstrap";
import CanvasJSReact from "../canvasjs.react";
import {SingleDataService} from "../../service/SingleDataService";

var CanvasJSChart = CanvasJSReact.CanvasJSChart;

export default class WorldDataTopRow extends Component{
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



        }
    }

    async componentWillMount() {
        const service = new SingleDataService()
        let response = await service.getWorldData()
        let countriesData = response.Countries.map((element)=>({y:element.TotalConfirmed, label:element.Country})).sort((a, b) => a.y < b.y ? 1 : -1)
        this.setState({
            globalData:    response.Global,
            countryData: countriesData
        })
    }

    render() {
        const total = this.state.globalData.TotalConfirmed
        const death = this.state.globalData.TotalDeaths
        const recovered = this.state.globalData.TotalRecovered
        const other = total-death-recovered

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
                    { y: Math.round(recovered/total*100).toFixed(2), label: "Recovered Cases" },
                    { y: Math.round(death/total*100).toFixed(2), label: "Death" },
                    { y: Math.round(other/total*100).toFixed(2),label: "Other"}
                ]
            }]
        }

        const barChartOptions = {
            animationEnabled: true,
            theme: "light2",
            title:{
                text: "Countries with the highest confirmed cases"
            },
            axisX: {
                title: "Countries",
                reversed: true,
            },
            axisY: {
                title: "Number of Cases",
                labelFormatter: this.addSymbols
            },
            data: [{
                type: "bar",
                dataPoints: this.state.countryData.slice(0,10)
            }]
        }

        return <CardDeck style={{marginTop:'2vh'}}>
            <Card>
                <Card.Body>
                    <Card.Title> World Summary</Card.Title>
                    <Card.Text>
                        <CanvasJSChart options = {barChartOptions}/>
                    </Card.Text>

                </Card.Body>
            </Card>
            <Card>
                <Card.Body>
                    <Card.Title> Death vs Recovery</Card.Title>
                    <Card.Text>
                        <CanvasJSChart options = {options}/>
                    </Card.Text>
                </Card.Body>
            </Card>
        </CardDeck>
    }
}
