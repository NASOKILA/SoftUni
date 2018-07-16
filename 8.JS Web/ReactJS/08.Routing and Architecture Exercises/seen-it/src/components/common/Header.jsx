import React, {Component} from 'react'
import '../../styles/header.css'

import observer from '../../Infrastructure/observer'

export default class Header extends Component {
    
    constructor(props){
        super(props);

        this.state = {
            username: null 
        }
    
        //we pass the userLoggedIn function to the loginUser event  
        observer.subscribe(observer.events.loginUser, this.userLoggedIn);
    }

    userLoggedIn = username => {
        this.setState({ username });
    }

    render(){
        
        const loggedInSection = 
            <div id="profile">
                <span>Hello, {this.state.username}</span> | <a href="#/logout">logout</a>
            </div>

        return (
        <header>
            <span class="logo">☃</span><span class="header">SeenIt</span>
            {this.state.username ? loggedInSection : null}
        </header>
        )
    }
}

