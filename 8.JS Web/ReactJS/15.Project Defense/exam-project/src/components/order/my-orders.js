import React, { Component } from 'react'
import requester from '../../Infrastructure/remote';

export default class MyOrders extends Component {
    constructor(props) {
        super(props);

        this.state = {
            orders: null,
            user: null
        }
    }

    componentDidMount = () => {

        requester.get('appdata', 'Orders', 'kinvey')
            .then(allOrders => {

                let orders = allOrders.filter(o => o.Customer === localStorage.getItem('username'));

                requester.get('user', '', 'kinvey')
                    .then(users => {

                        let user = users.filter(u => u.username === localStorage.getItem("username"))[0];
                        
                        this.setState({
                            orders,
                            user
                        });
                    })
                    .catch(err => console.log(err));
            })
            .catch(err => console.log(err));
    }

    render() {

        let counter = 0;

        if (this.state.orders === null || this.state.user === null) {
            return null;
        }

        if (this.state.orders.length < 1) {
            return (

                <main className="mt-3 mb-5">

                    <h1 className="text-center">My Orders</h1>
                    <hr className="hr-2 bg-dark" />

                    <table className="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Order Id</th>
                                <th scope="col">House Id</th>
                                <th scope="col">Customer</th>
                                <th scope="col">House Location</th>
                                <th scope="col">Ordered On</th>
                            </tr>
                        </thead>
                        <tbody>
                            <br />
                            <h1 className="text-center">No orders in DB.</h1>
                        </tbody>
                    </table>
                </main>)
        }


        return (

            <main className="mt-3 mb-5">

                <h1 className="text-center">My Orders</h1>
                <hr className="hr-2 bg-dark" />

                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Order Id</th>
                            <th scope="col">House Id</th>
                            <th scope="col">Customer</th>
                            <th scope="col">House Location</th>
                            <th scope="col">Ordered On</th>
                        </tr>
                    </thead>
                    <tbody>

                        {this.state.orders.map(o => {

                            return <tr key={counter}>
                                <th scope="row">{++counter}</th>
                                <td><a className="TableOrderId" href={'/order/details/' + o._id}>{o._id}</a></td>
                                <td><a className="TableOrderId" href={'/house/details/' + o.Product._id}>{o.Product._id}</a></td>
                                <td><a className="TableOrderId" href={'/user/profile/' + this.state.user._id}>{o.Customer}</a></td>
                                <td>{o.Product.Location}</td>
                                <td>{o.OrderedOn}</td>
                            </tr>
                        })}

                    </tbody>
                </table>
            </main>
        )
    }
}