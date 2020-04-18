import React from 'react';
import {Card,CardDeck} from "react-bootstrap";
import SummaryTable from "./SummaryTable";
import {SummaryPieChart} from "./SummaryPieChart";

export default function Home() {
    return(
        <div style={{marginTop:'1vh'}}>
            <CardDeck>
                <Card>
                    <Card.Body>
                        <Card.Title> New Zealand Summary</Card.Title>
                        <Card.Text>On 16 May 2020</Card.Text>
                        <SummaryTable/>
                    </Card.Body>
                </Card>
                <Card>
                    <Card.Body>
                        <Card.Title> This is the title</Card.Title>
                        Put other components inside the body
                        This card should be same size as the other
                        <SummaryPieChart></SummaryPieChart>
                    </Card.Body>
                </Card>
            </CardDeck>
        </div>
    )
}
