import React from 'react';
import {Card,CardDeck} from "react-bootstrap";

export default function Home() {
    return(
        <div style={{marginTop:'1vh'}}>
            <CardDeck>
                <Card>
                    <Card.Body>
                        <Card.Title> New Zealand Summary</Card.Title>
                        <Card.Text>On 16 May 2020</Card.Text>
                        Need to put a table here
                    </Card.Body>
                </Card>
                <Card>
                    <Card.Body>
                        <Card.Title> This is the title</Card.Title>
                        Put other components inside the body
                        This card should be same size as the other
                    </Card.Body>
                </Card>
            </CardDeck>
        </div>
    )
}
