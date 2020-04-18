import React,{Component} from 'react';
import CanvasJSReact from "../canvasjs.react";

var CanvasJSChart = CanvasJSReact.CanvasJSChart;


export class SummaryPieChart extends Component{
    constructor(props){
        super(props)
    }

    render() {
        const recPercentage = Math.round(this.props.tableData.recoveredCases/this.props.tableData.confirmedCases*100).toFixed(2)
        const deathPercentage = Math.round(this.props.tableData.totalDeath/this.props.tableData.confirmedCases*100).toFixed(2)
        const otherPercentage = 100-recPercentage-deathPercentage

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
                    { y: recPercentage, label: "Recovered Cases" },
                    { y: deathPercentage, label: "Death" },
                    { y: otherPercentage,label: "Other"}
                ]
            }]
        }
        return (
            <div>
                <CanvasJSChart options = {options}
                    /* onRef={ref => this.chart = ref} */
                />

            </div>
        );
    }
}
