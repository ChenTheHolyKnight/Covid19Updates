import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {ApiCallType, SingleDataService} from "../../service/SingleDataService";
import {number} from "prop-types";

export default class SummaryTable extends Component{
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

    render(){
        return (<Table>
            <thead>
            <tr>
                <th>Categories</th>
                <th>Total</th>
                <th>New in last 24 hours</th>
            </tr>
            </thead>
            <tbody>
            <tr>
                <td>Total Cases</td>
                <td>{this.state.tableData.totalCases}</td>
                <td>{this.state.tableData.totalNewCases}</td>
            </tr>
            <tr>
                <td>Confirmed Cases</td>
                <td>{this.state.tableData.confirmedCases}</td>
                <td>{this.state.tableData.confirmedNewCases}</td>
            </tr>
            <tr>
                <td>Probable Cases</td>
                <td>{this.state.tableData.probableCases}</td>
                <td>Need new probable cases here</td>
            </tr>
            <tr>
                <td>Recovered Cases</td>
                <td>{this.state.tableData.recoveredCases}</td>
                <td>Need new recovered cases here</td>
            </tr>
            <tr>
                <td>Death Cases</td>
                <td>{this.state.tableData.totalDeath}</td>
                <td>{this.state.tableData.newDeathCases}</td>
            </tr>
            </tbody>
        </Table>)
    }

}
