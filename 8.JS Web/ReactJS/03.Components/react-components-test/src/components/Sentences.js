import React, {Component} from 'react';

import './css/Sentences.css';
class Sentences extends Component {

    
    render(){
        
        let first = this.props.first || 'First';
        let second = this.props.second || 'Second';
        let third = this.props.third || 'Third';

        return (        
        <div className="Sentences">
            <h1>Sentence One: {first}</h1>
            <h1>Sentence Two: {second}</h1>
            <h1>Sentence Three: {third}</h1>
        </div>
        )
    }
}
export default Sentences;