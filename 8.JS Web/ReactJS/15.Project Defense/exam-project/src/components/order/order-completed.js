import React, { Component } from 'react'
import requester from '../../Infrastructure/remote';


export default class OrderCompleted extends Component {

    constructor(props){
        super(props);

        this.state = {
            order: null,
            message: '',
            error: false
        }
    }

    componentDidMount = () => this.sethouseState();

    sethouseState = () => {
        let id = this.props.match.params.id;

        
        requester.get('appdata', 'Houses/' + id, 'kinvey')
            .then(house => {
                
                requester.update('appdata', 'Houses/' + house._id, 'kinvey', {
                    'Location' : house.Location, 
                    'Size' : house.Size, 
                    'Price': house.Price,
                    'Image': house.Image,
                    'Description': house.Description,
                    'Sold': 'true'
                })
                .then(updatedHouse => {


                    requester.post('appdata', 'Orders', 'Basic', {
                        'OrderedOn' : new Date(Date.now()).toLocaleString(), 
                        'Customer' : localStorage.getItem("username"), 
                        'Product': updatedHouse,
                        })
                        .then(order => {
                        
                        this.setState({
                            message: "Congratulations Order Created Successfully !",
                            order
                            })
        
                        }).catch(err => console.log(err));

                }).catch(err => console.log(err));

            })
            .catch(err => console.log(err));                    
    }

    render() {
        
        if(this.state.error){
            return (
                <div className="container-fluid text-center">
                    <h1>{this.state.message}</h1>
                    <br/>
                    <h3>You cannot buy it !</h3>
                </div>
            )
        }

        if(this.state.order !== null){
            return (
                <div className="container-fluid text-center">
                    <h1>{this.state.message}</h1>
                    <br/>
                    <h2>Order Completed on {this.state.order.OrderedOn}.</h2>
                    <br/>
                    <h3>Enjoy your new house :)</h3>
                </div>
            )
        }
        else
        {
            return (
                <div>
                </div>
           )
        }
    }
}