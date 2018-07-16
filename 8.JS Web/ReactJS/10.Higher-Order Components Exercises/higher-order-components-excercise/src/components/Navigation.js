import React, { Component } from 'react';
import addStyle from '../helpers/addStyle';

class Navigation extends Component {
    
    render(){

        return (
            <nav>
        <header><span className="title">Navigation</span></header>
        <ul>
            <li><a href="#">Home</a></li>
            <li><a href="#">Catalog</a></li>
            <li><a href="#">About</a></li>
            <li><a href="#">Contact Us</a></li>
        </ul>
        </nav>
          )
    }
} 

Navigation.warning = true;

const NavigationWarning = addStyle(Navigation);

export default NavigationWarning;

