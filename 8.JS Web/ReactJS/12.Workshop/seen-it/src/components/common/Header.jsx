import React, {Component} from 'react';
import '../../styles/header.css';
import observer from '../../infrastructure/observer';

import {Link} from 'react-router-dom';

export default class Header extends Component {
    constructor(props) {
        super(props);
        this.state = { username: null };

        observer.subscribe(observer.events.loginUser, this.userLoggedIn);
    }

    userLoggedIn = username =>
        this.setState({ username });

    render = () => {
        const loggedInSection =  
            <div id="profile">
                <span id="username">Hello, {this.state.username}!</span>|
                <Link to="/logout">logout</Link>
            </div>

        return (
            <header>
                <span className="logo">☃</span><span className="header">SeenIt</span>
                {this.state.username ? loggedInSection : null}
            </header>
        )
    }
}