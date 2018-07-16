import React, { Component } from 'react';

export default class List extends Component {
    
 
    render(){

        //Its important to use id's for each element for arrays and iteration 
        
        //we pass the items as props
        let items = this.props.items || [];
 
        console.log(items)
        return(
            <ul>
                {this.props.items.map(element => <li key={element.id}>{element.name}</li>)}
            </ul>
        )
    }
}