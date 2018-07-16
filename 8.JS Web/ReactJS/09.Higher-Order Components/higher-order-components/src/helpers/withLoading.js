import React, { Component } from 'react';


const withLoading = (WrappedComponent) => {

    return class extends Component {
        constructor(props){
            super(props);

            this.state = {
                ready: false,
                data:[]
            }
        }


    componentDidMount(){

        this.props
            .request()
            .then((data) => {
              
                this.setState({
                    ready : true,
                    data
                })
            })
            .catch((err) => {
                console.log(err);
            })
    }

        render(){

            if(this.state.ready) {
                return <WrappedComponent data={this.state.data} {...this.props}/>
            } 

            return <h1>Loading ...</h1>
        }

    }

}

export default withLoading;

