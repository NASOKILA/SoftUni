import React, {Component} from 'react';
import requester from '../../Infrastructure/remote'
import observer from '../../Infrastructure/observer';
//import '../../styles/submit.css'

export default class LoginForm extends Component {

    constructor(props) {
        super(props);

        this.state = {
            username: null,
            password: null
        }
    }

    handleChange = (ev) => {
        
        let fieldName = ev.target.name;
        let fieldValue = ev.target.value;

        this.setState({
            [fieldName]: fieldValue
        })
    }

    handleSubmit = (ev) => {
        ev.preventDefault();

        requester.post('user', 'login', 'basic', this.state)
            .then(res => {
                console.log(res)
                sessionStorage.setItem('authtoken', res._kmd.authtoken);
                localStorage.setItem('username', res.username);
                observer.trigger(observer.events.loginUser, res.username);    
            });        
    }

    render(){

        return (
        <form id="loginForm" onSubmit={this.handleSubmit}>
            <h2>Sign In</h2>
            <label>Username:</label>
            <input onChange={this.handleChange} name="username" type="text" />
            <label>Password:</label>
            <input onChange={this.handleChange} name="password" type="password" />
            <input id="btnLogin" value="Sign In" type="submit" />
        </form>)
    }
}

