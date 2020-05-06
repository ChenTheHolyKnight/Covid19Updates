import React,{Component} from 'react'
import {Card, CardDeck} from "react-bootstrap";

export default class WorldDataBottomRow extends Component{
    componentDidMount() {
    }

    render() {
        return <CardDeck style={{marginTop:"2vh"}}>
            <Card>
                <Card.Body>
                    <Card.Title> Title1</Card.Title>
                    <Card>
                        <Card.Title> Inner Title</Card.Title>
                    </Card>

                </Card.Body>
            </Card>
        </CardDeck>
    }
}
