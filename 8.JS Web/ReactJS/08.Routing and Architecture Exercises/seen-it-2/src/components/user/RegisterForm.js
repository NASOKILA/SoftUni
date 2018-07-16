import React, { Component } from 'react'
import requester from '../../Infrastructure/remote';
import observer from '../../Infrastructure/observer';


export default class RegisterForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: null,
            password: null,
            repeatPassword: null
        }
    }

    handleChange = (ev) => {
            
            let key = ev.target.name;

            let value = ev.target.value;
            
            this.setState({
                [key]:value
            })
    }

    handleSubmit = (ev) => {
        ev.preventDefault();

        if(this.state.password !== this.state.repeatPassword
            || this.state.password === null 
            || this.state.repeatPassword === null 
            || this.state.username === null

            || this.state.password.length < 3 
            || this.state.repeatPassword.length < 3 
            || this.state.username.length < 3)
        {
            observer.trigger(observer.events.notification, {error: true, message: "Invalid Input Fields!", type: 'error'})                    
        }
        else {
            requester.post('user', '', 'basic', {'username' : this.state.username, 'password' : this.state.password})
            .then(res => {
                console.log(res)
                observer.trigger(observer.events.notification, {success: true, message: "Register Successfully!", type: 'success'})    
            }).catch(err => {
                console.log(err)
                observer.trigger(observer.events.notification, {error: true, message: err.responseJSON.description, type: 'error'})                    
            });
        }
    }

    render() {
        return (
            <form id="registerForm" onSubmit={this.handleSubmit}>
                <h2>Register</h2>
                <label>Username:</label>
                <input onChange={this.handleChange} name="username" type="text" />
                <label>Password:</label>
                <input onChange={this.handleChange} name="password" type="password" />
                <label>Repeat Password:</label>
                <input onChange={this.handleChange} name="repeatPassword" type="password" />
                <input id="btnRegister" value="Sign Up" type="submit" />
            </form>
        )
    }
}