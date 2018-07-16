import React from 'react';
import withLogging from '../helpers/withLogging';

class SecondBase extends React.Component {
    
    //we skip this info because the functionality
     
    render(){
        return (<h1>Second</h1>)
    }
}


SecondBase.displayName = "Second";

const Second = withLogging(SecondBase);

export default Second;