import React,{Component} from 'react';
import {Form, FormControl,Button, FormGroup} from "react-bootstrap";

export default class EmailTextField extends Component {
    constructor(props) {
        super(props)
        /* 1. Initialize Ref */
        this.textInput = React.createRef();
    }

    handleChange() {
        /* 3. Get Ref Value here (or anywhere in the code!) */
        const value = this.textInput.current.value
    }

    render() {
        /* 2. Attach Ref to FormControl component */
        return (
            <Form style={{marginTop:'5vh'}}>
                <FormGroup>
                    <Form.Label>Email address</Form.Label>
                    <FormControl type="email"  ref={this.textInput} placeholder="Enter email" onChange={() => this.handleChange()} />
                    <Form.Text className="text-muted">
                        We'll never share your email with anyone else.
                    </Form.Text>
                </FormGroup>
                <Button type="submit" style={{marginTop:'5vh'}}>Submitb </Button>
            </Form>

        )
    }
}
