import React,{useState} from 'react'
import {Modal,Button,Form,FormGroup} from 'react-bootstrap'
import EmailTextField from "./EmailTextField";

export default function EmailRegModal(){

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);


    return(
        <>
            <Button variant={'dark'} onClick={handleShow}>
                Register
            </Button>
            <Modal show={show} onHide={handleClose} animation={false}>
                <Modal.Header closeButton style={{border: 'none'}}>
                    <Modal.Title>Email Registration</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    Register for receiving Covid-19 updates through your Email
                    <EmailTextField></EmailTextField>
                </Modal.Body>
            </Modal>
        </>
    )

}
