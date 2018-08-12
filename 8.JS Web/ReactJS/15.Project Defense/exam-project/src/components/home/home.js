import React, { Component } from 'react';
import requester from '../../Infrastructure/remote';

export default class Home extends Component {

    constructor(props) {
        super(props);

        this.state = {
            houses: []
        }
    }


    setHouses = () => {

        requester.get('appdata', 'Houses', 'kinvey')
            .then(houses => {

                let counter = 1;

                houses.forEach(houses => {
                    houses.key = counter.toString();
                    counter++;
                });

                this.setState({
                    houses
                });

            })
            .catch(err => console.log(err));
    }

    render() {

        if (localStorage.getItem('username')) {
            this.setHouses();
            let role = localStorage.getItem('admin') === 'true'
                ? "Admin"
                : "User";

            return (

                <main className="mt-3 mb-5">
                    <div className="container-fluid text-center">
                        <h2>Greetings, {role} [ {localStorage.getItem('username')} ] !</h2>
                        <h4>Feel free to view and order any of our products.</h4>
                    </div>
                    <hr className="hr-2 bg-dark" />
                    <div className="container-fluid product-holder">
                        <div className="row d-flex justify-content-around mt-3">

                            {this.state.houses.map(h => {

                                let classSold = "";
                                let avaliable = "Avaliable";

                                if (h.Sold === "true") {
                                    classSold = "classSold";
                                    avaliable = "Sold";
                                }

                                return <a key={h.key} href={"/house/details/" + h._id} className="col-md-3">
                                    <div className={classSold + " product p-1 chushka-bg-color rounded-top rounded-bottom"}>

                                        <h5 className="text-center mt-3">{h.key}</h5>
                                        <h5 className="text-center mt-3">{avaliable}</h5>
                                        <hr className="hr-1 bg-white" />
                                        <h5 className="text-center mt-3">{h.Location}</h5>
                                        <hr className="hr-1 bg-white" />
                                        <p className="text-white text-center">
                                            <img class="animated bounce infinite" src={h.Image.toString()} alt="No House Img" />
                                            <br />
                                            {h.Description.toString().slice(0, Math.min(h.Description.toString().length, 50)) + " . . ."}
                                        </p>
                                        <hr className="hr-1 bg-white" />
                                        <h6 className="text-center text-white mb-3">${h.Price}</h6>
                                        <h6 className="text-center text-white mb-3">{h.Size + " Meters"}</h6>
                                    </div>
                                </a>
                            })}

                        </div>
                    </div>
                </main>
            )
        }

        return (

            <div className="jumbotron mt-3 chushka-bg-color">
                <h1>Welcome to my Universal Web     </h1>
                <hr className="bg-white" />
                <h3><a className="nav-link-dark" href="user/register">Register</a> if you don't have an account.</h3>
                <br />
                <h3><a className="nav-link-dark" href="user/login">Login</a> if you have an account.</h3>
            </div>
        )
    }
}