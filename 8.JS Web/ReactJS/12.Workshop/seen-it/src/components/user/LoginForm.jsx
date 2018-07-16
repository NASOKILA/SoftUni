import React, {Component} from 'react';

import withFormManager from './../../hocs/withFormManager';
import userModel from '../../models/userModel'
import userService from '../../services/userService'

class LoginForm extends Component {
    render = () => {
        return (
             <form id="loginForm" onSubmit={this.props.handleSubmit}>
                <h2>Sign In</h2>
                <span if="form-error">{this.props.error}</span>
                <label>Username:</label>
                <input name="username" onChange={this.props.handleChange} type="text" value={this.props.username} />
                <label>Password:</label>
                <input name="password" onChange={this.props.handleChange} type="password" value={this.props.password} />
                <input id="btnLogin" type="submit" value="Sign In" />
            </form>
        )
    }
}

export default withFormManager(LoginForm, userModel, userService.login);