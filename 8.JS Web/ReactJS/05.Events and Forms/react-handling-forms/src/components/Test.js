import React, {Component} from 'react';


export default class Test extends Component
{

    //We have to set the 'this' keyword 
    constructor(props) {
        super(props)
            this.onBtnClicked = this.onBtnClicked.bind(this);
    }

    //we reeive the 'event' automativcally
    onBtnClicked(event){
        console.log(event.target);
        alert(this.props.alertMessage);
    }

    render(){

        return (
            <button onClick={this.onBtnClicked}>Click me !</button>
        )
    }
}       

