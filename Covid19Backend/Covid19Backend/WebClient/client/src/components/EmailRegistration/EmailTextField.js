import React,{Component} from 'react';
import {Form, FormControl,Button, FormGroup} from "react-bootstrap";
import {SingleDataService} from "../../service/SingleDataService";
import {PostDataService} from "../../service/PostDataService";
import {string} from "prop-types";

export default class EmailTextField extends Component {
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
        this.state.value = this.textInput.current.value
    }

    async handleFormSubmit(event){
        const service = new PostDataService
        debugger
        if(this.state.email)
            await service.postApiData(this.state.email)

    }

    render() {

        /* 2. Attach Ref to FormControl component */
        return (
            <Form style={{marginTop:'5vh'}} onSubmit={this.handleFormSubmit}>
                <FormGroup>
                    <Form.Label>Email address</Form.Label>
                    <FormControl type="email"  ref={this.textInput} placeholder="Enter email" onChange={this.handleChange = this.handleChange.bind(this)} />
                    <Form.Text className="text-muted">
                        We'll never share your email with anyone else.
                    </Form.Text>
                </FormGroup>
                <Button type="submit" style={{marginTop:'5vh'}}>Submit</Button>
            </Form>

        )
    }
}
