import React, { Component } from 'react';

//importvame css koito da afektira nash klas
import './css/Welcome.css';

import Button from './Button';


//Every function with Capital letter can be a component
//but its better to use the Component class from React because we can use properties
class Welcome extends Component {

    render() {

        let title = this.props.title || 'Title';
        let subtitle = this.props.subtitle || 'Subtitle';
        
        //slagame mu klas za da mu napishem css
        return (<h1 className="Welcome">Welcome from {title} {subtitle}</h1>);
    
    }
}

export function WelcomeFunction(){
    return( 
    <div>
        <h1>Welcome Function Exported</h1>
        <Button text="Some Text"/>
    </div>);
}

export default Welcome;
