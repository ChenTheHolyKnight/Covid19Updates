import NavMenu from "./NavMenu";
import React from "react";
import {  Container } from 'react-bootstrap';

export default function  Layout(props) {
    return (
        <React.Fragment>
            <NavMenu/>
            <Container>
                {props.children}
            </Container>
        </React.Fragment>
    );
}
