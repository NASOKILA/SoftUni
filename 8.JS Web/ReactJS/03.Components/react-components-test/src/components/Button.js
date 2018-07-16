import React, {Component} from 'react';

import rerender from '../index'; 

import App from '../App';

class Button extends Component {

    //If we want to use the state of a component we must do the following

    //we pass the props to the base class thrue the constructor
    constructor (props){
        super(props)
    
        //we initializa the default state
        this.state = {
            count:0,
            isOn: false
        }
    }

    
    //We declare the function ouside the render method
    IncreaseStateCount() {

        //to update the state we can use the setState() function, this just updates the setate, it does not override it !!!!
        this.setState({
            count: this.state.count + 1,
            isOn: !this.state.isOn
            //the color stil exists it does not dissapear
        })

        //this.state.count++
        rerender(<App />, document.getElementById('root'));
    }
        
    
    render(){
     
        return (
            //(e) => this.IncreaseStateCount(e) 
            <button onClick={this.IncreaseStateCount.bind(this)}>
                {this.props.text || 'No Text'} Clicked {this.state.count} Times ! {this.state.isOn ? "ON" : "OFF"}
            </button>
        )
    }
}

export default Button;
