import React, {Component} from 'react';

import withFormManager from './../../hocs/withFormManager';
import userModel from '../../models/userModel'
import userService from '../../services/userService'

class RegisterForm extends Component {
    render = () => {
        return (
            <form id="registerForm" onClick={this.props.handleSubmit}>
                <h2>Register</h2>
                <label>Username:</label>
                <input name="username" 
                    type="text" 
                    onChange={this.props.handleChange} 
                    value={this.props.username}/>
                <label>Password:</label>
                <input name="password" 
                    type="password" 
                    onChange={this.props.handleChange} 
                    value={this.props.password}/>
                <label>Repeat Password:</label>
                <input name="repeatPass" type="password" onChange={this.props.handleChange} />
                <input id="btnRegister" type="submit" value="Sign Up" />
            </form>
        )
    }
}

export default withFormManager(RegisterForm, userModel, userService.register);