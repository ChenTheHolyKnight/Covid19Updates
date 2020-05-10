import React, {Component} from "react";
import {string} from "prop-types";
import {PostDataService} from "../../service/PostDataService";
import {Button, Form, FormControl, FormGroup} from "react-bootstrap";

export default class TextField extends Component {
    constructor(props) {
        super(props)
        /* 1. Initialize Ref */
        this.textInput = React.createRef();
        this.state = {
            value: string,
            email: ''
        }

        this.handleFormSubmit = this.handleFormSubmit.bind(this);
    }

    handleChange(event){
        /* 3. Get Ref Value here (or anywhere in the code!) */
        event.preventDefault()
        this.setState({email:event.target.value})
    }

    async handleFormSubmit(event){
        const service = new PostDataService
        debugger
        console.log("Submitted")

    }

    render() {

        /* 2. Attach Ref to FormControl component */
        return (
            <Form inline style={{display: "flex",justifyContent: "flex-end"}} onSubmit={this.handleFormSubmit}>
                <FormGroup>
                    <FormControl type="text"  ref={this.textInput} placeholder="Enter email" onChange={this.handleChange = this.handleChange.bind(this)} />
                </FormGroup>
                <Button type="submit">Submit</Button>
            </Form>

        )
    }
}
