import React, {Component} from 'react';

class Error extends Component {
    constructor(props){
        super(props)
    }


    render() {
        return(
            <h1 className="alert-danger">{this.props.output}</h1>
        )
    }

}

export default Error;