import React, { Component } from 'react'
import requester from '../../Infrastructure/remote';

export default class Details extends Component {

    constructor(props) {
        super(props);

        this.state = {
            house: null
        }
    }

    componentDidMount = () => this.sethouseState();

    sethouseState = () => {
        let id = this.props.match.params.id;

        requester.get('appdata', 'Houses/' + id, 'kinvey')
            .then(house => {
                this.setState({
                    house
                });

            })
            .catch(err => console.log(err));
    }

    render() {

        if (this.state.house !== null) {


            if(this.state.house.Sold === 'true'){
                
            return (
                <div>
                    <main className="mt-3 mb-5">

                        <h1 className="text-center">Details Page</h1>
                        <br />
                        <h1 className="text-center">{this.state.house.Location}</h1>
                        <br />

                        <hr className="hr-2 bg-dark" />
                        <div className="product-type-holder half-width mx-auto d-flex justify-content-between">
                            <h3 className="text-center">Price:  {this.state.house.Price} $</h3>
                            <h3 className="text-center">Size:  {this.state.house.Size} Square Meters</h3>
                        </div>
                        <hr className="hr-2 bg-dark" />
                        <br />
                        <h1 className="text-center">{this.state.house.Sold === 'true' ? 'Sold' : 'Avaliable'}</h1>
                        <br />
                        <img className="image-details" src={this.state.house.Image} alt="No House Img" />
                        <br />
                        <br />
                        <h3 className="text-center">Description</h3>
                        <div className="product-description-holder">
                            <p className="text-center mt-4">
                                {this.state.house.Description}
                            </p>
                        </div>
                        <br />
                        <hr className="hr-2 bg-dark" />
                        <h3 className="text-center">Actions</h3>
                        <div className="product-action-holder mt-4 d-flex justify-content-around">

                            {this.state.house.Sold === "false"
                                ? <a className="btn chushka-bg-color" href={"/house/confirm-order/" + this.state.house._id}>Order</a>
                                : ""}

                            {localStorage.getItem("admin") === 'true'
                                ? <a className="btn chushka-bg-color" href={"/house/delete/" + this.state.house._id}>Delete</a>
                                : ""}
                        </div>
                    </main>
                    <br />
                    <br />
                </div>
            )
            }


            return (
                <div>
                    <main className="mt-3 mb-5">

                        <h1 className="text-center">Details Page</h1>
                        <br />
                        <h1 className="text-center">{this.state.house.Location}</h1>
                        <br />

                        <hr className="hr-2 bg-dark" />
                        <div className="product-type-holder half-width mx-auto d-flex justify-content-between">
                            <h3 className="text-center">Price:  {this.state.house.Price} $</h3>
                            <h3 className="text-center">Size:  {this.state.house.Size} Square Meters</h3>
                        </div>
                        <hr className="hr-2 bg-dark" />
                        <br />
                        <h1 className="text-center">{this.state.house.Sold === 'true' ? 'Sold' : 'Avaliable'}</h1>
                        <br />
                        <img className="image-details" src={this.state.house.Image} alt="No House Img" />
                        <br />
                        <br />
                        <h3 className="text-center">Description</h3>
                        <div className="product-description-holder">
                            <p className="text-center mt-4">
                                {this.state.house.Description}
                            </p>
                        </div>
                        <br />
                        <hr className="hr-2 bg-dark" />
                        <h3 className="text-center">Actions</h3>
                        <div className="product-action-holder mt-4 d-flex justify-content-around">

                            {this.state.house.Sold === "false"
                                ? <a className="btn chushka-bg-color" href={"/house/confirm-order/" + this.state.house._id}>Order</a>
                                : ""}

                            {localStorage.getItem("admin") === 'true'
                                ? <a className="btn chushka-bg-color" href={"/house/edit/" + this.state.house._id}>Edit</a>
                                : ""}

                            {localStorage.getItem("admin") === 'true'
                                ? <a className="btn chushka-bg-color" href={"/house/delete/" + this.state.house._id}>Delete</a>
                                : ""}
                        </div>
                    </main>
                    <br />
                    <br />
                </div>
            )
        }
            return (<div></div>)
    }
}



