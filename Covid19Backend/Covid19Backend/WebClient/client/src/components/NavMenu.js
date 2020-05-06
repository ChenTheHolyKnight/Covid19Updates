
import {  Navbar, Nav,Button } from 'react-bootstrap';
import React, {useState} from "react";
import EmailRegModal from "./EmailRegistration/EmailRegModal";
export default function NavMenu() {
    const [show,setShow] = useState(false)


    return(<div>
            <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
                <Navbar.Brand href="/">Covid-19 Updates</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="mr-auto">
                        <Nav.Link href="/ ">Home</Nav.Link>
                        <Nav.Link href="/worldData">World Statistics</Nav.Link>
                    </Nav>
                    <EmailRegModal/>
                </Navbar.Collapse>
            </Navbar>
        </div>

    )
}
