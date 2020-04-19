import React,{Component,useState} from 'react'
import {Modal,Button} from 'react-bootstrap'

export default function EmailRegModal(props){

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);


    return(
        <>
            <Button variant={'dark'} onClick={handleShow}>
                Register
            </Button>
            <Modal show={show} onHide={handleClose} animation={false}>
                <Modal.Header closeButton>
                    <Modal.Title>Email Registration</Modal.Title>
            </Modal.Header>
                <Modal.Body>Register for receiving Covid-19 updates through your Email</Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancel
                    </Button>
                    <Button variant="primary" onClick={handleClose}>
                        Register
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    )

}
