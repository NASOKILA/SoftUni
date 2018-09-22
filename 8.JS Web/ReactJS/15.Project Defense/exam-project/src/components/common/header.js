import React, { Component } from 'react'
export default class header extends Component {


    componentDidMount() {
        // Close the dropdown menu if the user clicks outside of it
        window.onclick = function (event) {
            if (!event.target.matches('.dropbtn')) {

                var dropdowns = document.getElementsByClassName("dropdown-content");
                var i;
                for (i = 0; i < dropdowns.length; i++) {
                    var openDropdown = dropdowns[i];
                    if (openDropdown.classList.contains('show')) {
                        openDropdown.classList.remove('show');
                    }
                }
            }
        }
    }


    myFunction() {
        document.getElementById("myDropdown").classList.toggle("show");
    }


    render() {


        if (localStorage.getItem('admin') === 'true') {

            return (
                <div className="headerDiv">
                    <header>

                        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                            <a className="navbar-brand" href="/house-shop/">HouseShop</a>
                            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
                                <span className="navbar-toggler-icon"></span>
                            </button>

                            <div className="collapse navbar-collapse" id="navbarColor02">
                                <ul className="navbar-nav mr-auto">

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop">Home</a>
                                    </li>

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/about">About</a>
                                    </li>

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/user/profile/:id">Profile</a>
                                    </li>

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/order/my">My Orders</a>
                                    </li>

                                </ul>

                                <div className="dropdown">
                                    <button onClick={this.myFunction} className="dropbtn">[ Admin &#8691; ]</button>
                                    <div id="myDropdown" class="dropdown-content">
                                        <a className="nav-link nav-link-white" href="/house-shop/house/create">Create House</a>
                                        <a className="nav-link nav-link-white" href="/house-shop/order/all">All Orders</a>
                                    </div>
                                </div>

                                <ul className="navbar-nav left-side">
                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/user/logout">Logout</a>
                                    </li>
                                </ul>
                            </div>
                        </nav>

                    </header>
                </div>)
        }

        if (localStorage.getItem('username')) {
            return (

                <div className="headerDiv">
                    <header>
                        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                            <a className="navbar-brand" href="/house-shop/">HouseShop</a>
                            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
                                <span className="navbar-toggler-icon"></span>
                            </button>

                            <div className="collapse navbar-collapse" id="navbarColor02">
                                <ul className="navbar-nav mr-auto">

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/">Home</a>
                                    </li>

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/about">About</a>
                                    </li>

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/user/profile/:id">Profile</a>
                                    </li>

                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/order/my">My Orders</a>
                                    </li>

                                </ul>

                                <ul className="navbar-nav left-side">
                                    <li className="nav-item">
                                        <a className="nav-link nav-link-white" href="/house-shop/user/logout">Logout</a>
                                    </li>
                                </ul>
                            </div>
                        </nav>
                    </header>
                </div>)
        }


        return (
            <div className="headerDiv">
                <header className="header">
                    <nav className="navbar navbar-expand-lg navbar-dark bg-dark nav">
                        <a className="navbar-brand" href="/house-shop/">HouseShop</a>
                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>

                        <div className="collapse navbar-collapse" id="navbarColor02">
                            <ul className="navbar-nav mr-auto">

                                <li className="nav-item">
                                    <a className="nav-link nav-link-white" href="/house-shop">Home</a>
                                </li>

                                <li className="nav-item">
                                    <a className="nav-link nav-link-white" href="/house-shop/about">About</a>
                                </li>
                            </ul>

                            <ul className="navbar-nav left-side">
                                <li className="nav-item">
                                    <a className="nav-link nav-link-white" href="/house-shop/user/login">Login</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link nav-link-white" href="/house-shop/user/register">Register</a>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </header>
            </div>
        )

    }
}

