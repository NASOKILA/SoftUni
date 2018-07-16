import React, {Component} from '../../../../../../../../../AppData/Local/Microsoft/TypeScript/2.9/node_modules/@types/react';

import {Redirect} from '../../../../../../../../../AppData/Local/Microsoft/TypeScript/2.9/node_modules/@types/react-router-dom';

import requester from '../../Infrastructure/remote'

import observer from '../../Infrastructure/observer';

export default class Logout extends Component {

    logout = () => {
        requester.post('user', 'logout', 'kinvey')
        .then(res => {
            sessionStorage.clear();
            localStorage.clear();
        });
    }

    render = () => <Redirect to='/' />
}