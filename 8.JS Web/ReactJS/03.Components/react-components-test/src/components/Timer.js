import React from 'react';


class Timer extends React.Component {

    constructor(props) {
        super(props)

        //we initialize the state in the constructor
        this.state = {
            date: new Date(Date.now()).toLocaleString()
        }
    }


    
    //updates the current date & time
    tick() {
        this.setState({
            date : new Date().toLocaleString()
        })

    }

    //we will use the componentDidMount to start a setInterval which will run our tick() function 
    //which updates the 'date' in the 'state'
    componentDidMount(){

        //we attach it to the context so we can delete it later
        this.timer = setInterval(() => {
            this.tick();    
        },1000)
    


        fetch('https://www.google.bg/')
            .then((res) => {
                console.log(res)
            })
            .catch(err => console.log(err))


    }


    //componentWillUnmount will help us delete the setInterval if we decide to delete the 
    //timer otherwise it will keep going
    componentWillUnmount(){

        //if the timer is deleted or removed we clear the Interval()
        clearInterval(this.timer);
    }


    render() {
        return (
            <h1>Date and Time is: {this.state.date}</h1>
        )
    }

}

export default Timer;