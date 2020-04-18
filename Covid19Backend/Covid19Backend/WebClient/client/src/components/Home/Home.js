import React,{Component} from 'react';
import {Card,CardDeck} from "react-bootstrap";
import SummaryTable from "./SummaryTable";
import {SummaryPieChart} from "./SummaryPieChart";
import {number} from "prop-types";
import {ApiCallType, SingleDataService} from "../../service/SingleDataService";

export default class Home extends Component{

    constructor(props){
        super(props);
        this.state = {
            tableData: {
                totalCases: number,
                totalNewCases: number,
                confirmedCases: number,
                confirmedNewCases: number,
                probableCases: number,
                recoveredCases:number,
                totalDeath: number,
                newDeathCases:number}
        }
    }
    async componentDidMount() {
        const service = new SingleDataService()
        let data = await service.getApiData(ApiCallType.DailyReport);
        this.setState({
            tableData: data
        })
    }
    render()
    {
        return <div style={{marginTop:'1vh'}}>
                <CardDeck>
                    <Card>
                        <Card.Body>
                            <Card.Title> New Zealand Summary</Card.Title>
                            <Card.Text>On 16 May 2020</Card.Text>
                            <SummaryTable tableData={this.state.tableData}/>
                        </Card.Body>
                    </Card>
                    <Card>
                        <Card.Body>
                            <Card.Title> This is the title</Card.Title>
                            Put other components inside the body
                            This card should be same size as the other
                            <SummaryPieChart tableData={this.state.tableData}></SummaryPieChart>
                        </Card.Body>
                    </Card>
                </CardDeck>
            </div>

    }

}
