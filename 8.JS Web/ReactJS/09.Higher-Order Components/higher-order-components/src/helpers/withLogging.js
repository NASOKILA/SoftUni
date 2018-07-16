
import React, {Component} from 'react';

//function that receive a component and returns another component
function withLogging(ComponentParam){
    
    
    return class extends Component {
        constructor(params)
        {
            super(params);
            this.state = {

            }
        }

        componentDidMount(){
            console.log(`${ComponentParam.displayName} ready !`);
        }

        render(){
            //id we want to use the properties we need to pass them to the new generated component
            return <ComponentParam {...this.props}/>
        }
    }

}

export default withLogging;
