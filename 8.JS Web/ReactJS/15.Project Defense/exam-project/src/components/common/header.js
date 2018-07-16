import React, { Component } from 'react'
export default class Footer extends Component {

    render(){


        if(localStorage.getItem('admin') === 'true'){

            return (
            <header>
            <nav className="navbar navbar-expand-lg chushka-bg-color">
                <a className="navbar-brand nav-link-white" href="/">HouseShop</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse d-flex justify-content-between" id="navbarNav">
                    <ul className="navbar-nav right-side">
                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/">Home</a>
                        </li>

                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/about">About</a>
                        </li>

                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/user/profile/:id">Profile</a>
                        </li>
                        
                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/order/my">My Orders</a>
                        </li>

                        <li className="nav-item" >
                            <a className="nav-link nav-link-white" href="/order/all">All Orders</a>
                        </li>

                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/house/create">Create House</a>
                        </li>


                    </ul>
                    <ul className="navbar-nav left-side">
                    <li className="nav-item">
                    <a className="nav-link nav-link-white" href="/user/logout">Logout</a>
                    </li>
                    </ul>
                </div>
            </nav>
        </header>)
        }

        if(localStorage.getItem('username')){
            return (<header>
            <nav className="navbar navbar-expand-lg chushka-bg-color">
                <a className="navbar-brand nav-link-white" href="/">HouseShop</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse d-flex justify-content-between" id="navbarNav">
                    <ul className="navbar-nav right-side">
                    <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/">Home</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/about">About</a>
                        </li>
                        
                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/user/profile/:id">Profile</a>
                        </li>

                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/order/my">My Orders</a>
                        </li>

                    </ul>
                    <ul className="navbar-nav left-side">
                    <li className="nav-item">
                    <a className="nav-link nav-link-white" href="/user/logout">Logout</a>
                    </li>
                    </ul>
                </div>
            </nav>
        </header>)
        }


            return(
            
                <header className="header">
                    <nav className="navbar navbar-expand-lg chushka-bg-color">
                        <a className="navbar-brand nav-link-white" href="/">HouseShop</a>
                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse d-flex justify-content-between" id="navbarNav">
                            <ul className="navbar-nav right-side">
                            <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/">Home</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link nav-link-white" href="/about">About</a>
                        </li>
                        
                                <li className="nav-item" >
                                    <a className="nav-link nav-link-white" href="/user/login">Login</a>
                                </li>
                                <li className="nav-item" >
                                    <a className="nav-link nav-link-white" href="/user/register">Register</a>
                                </li>
                            </ul>
                            
                        </div>
                    </nav>
                </header>
                )
        
    }
}

