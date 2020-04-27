import React,{Component} from 'react'
import {PostDataService} from "../../service/PostDataService";


export default class EmailUnreg extends Component{

    constructor(props){
        super(props)
    }

    async componentDidMount() {
        let postDataService = new PostDataService;
        await postDataService.deleteData(this.props.match.params.email)
    }

    render(){
        let email = this.props.match.params.email;
        return<div style={{marginTop:'5vh'}}>
            <h1>Thank you</h1>
            <h4 style={{marginTop:'5vh'}}>You have been successfully removed from our subscribe list. You can register again by clicking the register button on the navigation menu</h4>
        </div>
    }
}
