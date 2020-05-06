import React,{Component} from 'react'
import {Card, CardDeck} from "react-bootstrap";
import SummaryTable from "../Home/SummaryTable";
import {SummaryPieChart} from "../Home/SummaryPieChart";
import WorldDataTopRow from "./WorldDataTopRow";
import WorldDataBottomRow from "./WorldDataBottomRow";

export default class WorldData extends Component{
    componentDidMount() {
    }

    render() {
        return <div style={{marginTop: "2vh"}}>
            <WorldDataTopRow></WorldDataTopRow>
            <WorldDataBottomRow></WorldDataBottomRow>
        </div>
    }
}
