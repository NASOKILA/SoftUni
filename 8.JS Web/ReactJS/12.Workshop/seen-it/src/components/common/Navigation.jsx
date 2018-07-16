import React, { Component } from 'react';
import {NavLink} from 'react-router-dom';
import '../../styles/menu.css';

export default class Navigation extends Component {
    render= () => (
        <div id="menu">
            <div className="title">Navigation</div>
            <NavLink className="nav" to='/'>Home</NavLink>
            <NavLink className="nav" to='/catalog'>Catalog</NavLink>
        </div>
    )
}