import React, { Component } from 'react'

export default class Error extends Component {

    render() {


        return (
            <div className="text-white p-2 text-center">
                
                <div className="jumbotron detailsActions bg-dark">
                        <p className="text-center display-3">404 Page Not Found</p>
                        <hr className="hr-2 bg-white" />
                        <div className="product-action-holder mt-4 d-flex justify-content-around">
                            <a className="btn btn-lg btn-secondary housebuttons" href={"/house-shop"}>Back to home</a>
                        </div>
                    </div>
            </div>

        )
    }
}