import React, {Component} from 'react';
import {Redirect} from 'react-router-dom';
import requester from '../../Infrastructure/remote';

export default class Logout extends Component {

    logout = () => {
        requester.post('user', 'logout', 'kinvey')
        .then(res => {
            sessionStorage.clear();
            localStorage.clear();
        });
    }
            
    render = () => {

        this.logout();
        return <Redirect to='/' />
    }

}