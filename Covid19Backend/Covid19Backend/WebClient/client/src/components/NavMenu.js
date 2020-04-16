
import {  Navbar, Nav, } from 'react-bootstrap';
import React from "react";
export default function NavMenu() {
    return(
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
            <Navbar.Brand href="/">Covid-19 Updates</Navbar.Brand>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="mr-auto">
                    <Nav.Link href="/ ">Home</Nav.Link>
                    <Nav.Link href="#pricing">World Statistics</Nav.Link>
                </Nav>
                <Nav>
                    <Nav.Link href="#deets">register</Nav.Link>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    )
}
