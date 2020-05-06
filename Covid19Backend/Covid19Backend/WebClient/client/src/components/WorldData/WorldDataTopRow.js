import React,{Component} from 'react'
import {Card, CardDeck} from "react-bootstrap";
import CanvasJSReact from "../canvasjs.react";

var CanvasJSChart = CanvasJSReact.CanvasJSChart;

export default class WorldDataTopRow extends Component{
    componentDidMount() {
    }

    render() {

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
                    { y: 30, label: "Recovered Cases" },
                    { y: 35, label: "Death" },
                    { y: 40,label: "Other"}
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
                dataPoints: [
                    { y:  2200000000, label: "Facebook" },
                    { y:  1800000000, label: "YouTube" },
                    { y:  800000000, label: "Instagram" },
                    { y:  563000000, label: "Qzone" },
                    { y:  376000000, label: "Weibo" },
                    { y:  336000000, label: "Twitter" },
                    { y:  330000000, label: "Reddit" }
                ]
            }]
        }

        return <CardDeck>
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
