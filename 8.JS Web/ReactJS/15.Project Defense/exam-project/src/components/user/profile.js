import React, { Component } from 'react';
import requester from '../../Infrastructure/remote';

export default class Profile extends Component {

    constructor(props) {
        super(props);

        this.state = {
            user: null,
            orders: null
        }
    }

    componentDidMount = () => this.getUser()

    getUser = () => {

        let id = this.props.match.params.id;
      
        if(id.length !== 24){
            requester.get('user', '', 'kinvey')
            .then(users => {
                    let user = users.filter(u => u.username === localStorage.getItem('username'))[0]
                   
                    requester.get('appdata', 'Orders', 'kinvey')
                .then(orders => {
    
                    this.setState({
                        user,
                        orders
                    });
                    
                })
                .catch(err => console.log(err));
                
            })
            .catch(err => console.log(err));
        }
        else
        {
            requester.get('user', id, 'kinvey')
            .then(user => {
                
                requester.get('appdata', 'Orders', 'kinvey')
                .then(orders => {
    
                    this.setState({
                        user,
                        orders
                    });
                    
                })
                .catch(err => console.log(err));
                
            })
            .catch(err => console.log(err));
        }
    }


    render() {

        if(this.state.orders === null || this.state.user === null){
            return null;
        }


        return (
            
            <main className="mt-3 mb-5">

                <h1 className="text-center">User Profile Page</h1>
                <br/>
                <br/>
                <h2>Username:</h2>
                <h1 className="text-center">{this.state.user.username}</h1>
                <br/>                        

                <hr className="hr-2 bg-dark" />
                <div className="product-type-holder half-width mx-auto d-flex justify-content-between">
                    <h3 className="text-center">Email: {this.state.user.email}</h3>
                    <h3 className="text-center">Houses bought: {this.state.orders.filter(o => o.Customer === this.state.user.username).length}</h3>
                </div>
                <hr className="hr-2 bg-dark" />
                <br/>                        
                <h3 className="text-center">Role:</h3>
                <div className="product-description-holder">
                    <h2 className="text-center mt-4">
                        {this.state.user._kmd.roles === undefined ? "User" : "Admin"}
                    </h2>
                </div>
                <hr className="hr-2 bg-dark" />
                <br/>
            </main>
        )

    }
}