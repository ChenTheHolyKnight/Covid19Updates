import React,{Component} from 'react';
import {Card,CardDeck} from "react-bootstrap";
import SummaryTable from "./SummaryTable";
import {SummaryPieChart} from "./SummaryPieChart";
import {number, string} from "prop-types";
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
                probableNew: number,
                probableCases: number,
                recoveredCases:number,
                recoveredNew: number,
                totalDeath: number,
                newDeathCases:number,
                reportDate: string
            }
        }
    }
    async componentWillMount() {
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
                            <Card.Text>On {this.state.tableData.reportDate}</Card.Text>
                            <SummaryTable tableData={this.state.tableData}/>
                        </Card.Body>
                    </Card>
                    <Card>
                        <Card.Body>
                            <Card.Title> Death vs Recovery</Card.Title>
                            <Card.Text>On {this.state.tableData.reportDate}</Card.Text>
                            <SummaryPieChart tableData={this.state.tableData}></SummaryPieChart>
                        </Card.Body>
                    </Card>
                </CardDeck>
            </div>

    }

}
