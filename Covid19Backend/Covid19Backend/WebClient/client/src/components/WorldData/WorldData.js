import React,{Component} from 'react'
import {Card, CardDeck} from "react-bootstrap";
import SummaryTable from "../Home/SummaryTable";
import {SummaryPieChart} from "../Home/SummaryPieChart";
import WorldDataTopRow from "./WorldDataTopRow";
import WorldDataBottomRow from "./WorldDataBottomRow";
import {SingleDataService} from "../../service/SingleDataService";

export default class WorldData extends Component{
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
            countryData: []


        }
    }

    async componentWillMount() {
        const service = new SingleDataService()
        let response = await service.getWorldData()
        this.setState({
            globalData:    response.Global,
            countryData: response.Countries
        })
    }

    render() {
        return <div style={{marginTop: "2vh"}}>
            <WorldDataTopRow data={this.state.globalData}></WorldDataTopRow>
            <WorldDataBottomRow data={this.state.countryData}></WorldDataBottomRow>
        </div>
    }
}
