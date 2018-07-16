import React, {Component} from 'react';

export default class RegisterForm extends Component {

    constructor(props){
        super(props)
        
        //we set the state first
        this.state = {
            user: {
                username :'',
                password : ''   
            },
            error : ''
        }

        
        //we have to bind all the functions 
        this.onInputChanged = this.onInputChanged.bind(this)
        this.onFormSubmit = this.onFormSubmit.bind(this)
    }

    //we will use this event to pass the input value parameters to the state
    //we can use the ame function for all the input fields if the names match 
    //with the ones in the user object in the tate
    onInputChanged (event) {

        let user = this.state.user;
        
        //set the the input fields to the user obj.
        let inputName = event.target.name;
        let inputValue = event.target.value;

        user[inputName] = inputValue;
        
        //set the user
        this.setState({user});
    }

    onFormSubmit (event) {

        //validations happen here
        if(this.state.user.username.length < 3){
            this.setState({
                error: "Username must be more than 3 syumbols !"
            })
        
            return;
        }
        else if(this.state.user.password.length < 3){
            this.setState({
                error: "Password must be more than 3 syumbols !"
            })
        
            return;
        }
        else 
        {
            //if there is no error we clear the error property from prevous errors.
            this.setState({error:''})
        }

        event.preventDefault();
        console.log(this.state.user);
    }


    render(){
        return (
            <form onSubmit={this.onFormSubmit}>
            <div>{this.state.error}</div>
                Username:
                <input 
                onChange={this.onInputChanged} 
                type="text" 
                name="username"
                value={this.state.username}/><br /><br />

                Password:
                <input 
                onChange={this.onInputChanged} 
                type="password" 
                name="password"
                value={this.state.password}/><br /><br />

                <input type="submit" value="Submit"/>
            </form>
        )
    }
}