import React from 'react';

import observer from '../../Infrastructure/observer'


export default class extends React.Component {
    constructor(props) {
        super(props);


        this.state = {
            message: null,
            success: null,
            error: null,
            loading: null
        }

        observer.subscribe(observer.events.notification, this.showNotification);
    }

    showNotification = (data) => {

        this.hideNotification();
        let message = data.message;
        let type = data.type;

        this.setState({
            [type]: true,
            message
        });
    }

    hideNotification = (ev) => {
        this.setState({
            message: null,
            success: null,
            error: null,
            loading: null
        })
    }

    render = () => {

        if (this.state.success) {
            return <div id="successBox" className="notification"><span>{this.state.message}</span></div>
        } else if (this.state.error) {
            return <div id="errorBox" className="notification"><span>{this.state.message}</span></div>
        } else if (this.state.loading) {
            return <div id="loadingBox" className="notification"><span>{this.state.message}</span></div>
        }

        return null;
    }

}