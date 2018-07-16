
import React, { Component } from 'react';

import { NavLink } from 'react-router-dom';

export default class Navigation extends Component {
    constructor(props) {
        super(props);

        this.state = {
        }
    }

    render() {
        return (    
            <div id="menu">
                <div className="title">Navigation</div>
                <a className="nav" href="/submit-link">Submit Link</a>
                <a className="nav" href="/my-posts">My Posts</a>
                <NavLink className="nav" to="/catalog" activeClassName="active">Catalog</NavLink>
            </div>)
    }

}




