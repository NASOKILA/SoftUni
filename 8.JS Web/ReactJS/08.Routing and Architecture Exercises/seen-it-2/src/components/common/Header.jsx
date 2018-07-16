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
                <span>Hello, {this.state.username}</span> | <a href="/logout">logout</a> | <a href="/catalog">Catalog</a>
            </div>

        return (
        <header>
            <span className="logo">☃</span><span className="header">SeenIt</span>
            {this.state.username ? loggedInSection : null}
        </header>
        )
    }
}

