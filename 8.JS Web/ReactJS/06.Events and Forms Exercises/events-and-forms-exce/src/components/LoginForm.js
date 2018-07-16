import React from 'react';
import Error from './Error';

export default class LoginForm extends React.Component {


constructor(props)
{
    super(props);

    this.state = {
        form : {
            email:'',
            password:''
        },
        error : 
        {
            state: false,
            message: ''
        }
    }

    this.submit = this.submit.bind(this);
    this.handleUpdate = this.handleUpdate.bind(this);
    this.isFormValid = this.isFormValid.bind(this);
}



    handleUpdate(e){

        
            let key = e.target.name;
            let value = e.target.value;
            let newForm = {};
            
            newForm[key] = value;
            
            this.setState({
                form : Object.assign(this.state.form, newForm)
            })
        

    }

    isFormValid(){

        let form = this.state.form;
        if (form.email === "") {
            
            let error = {};
            error.state = true;
            error.message = "Email field is required !";

            this.setState({
                error
            });

            return false;
        }
        else if (form.password === "") {
            
            let error = {};
            error.state = true;
            error.message = "Password field is required !";

            this.setState({
                error
            });

            return false;
        }
        else if (form.password.length < 8) {
            
            let error = {};
            error.state = true;
            error.message = "Password length should be more than 7 symbols !";

            this.setState({
                error
            });

            return false;
        }


        return true;

    }

    submit(e){
        
        
        if(this.isFormValid()){
        //we have to send a post request to http://localhost:5000/auth/login to Login
        fetch('http://localhost:5000/auth/login', {
            method:'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(this.state.form)
        })
        .then(data => data.json()).catch(err => console.log(err))
        .then(res => {
            console.log(res)
            if(res.success === true){
                localStorage.setItem('token', res['token']);
                localStorage.setItem('username', res['user']['name']);
            }
            else
            {
                let error = {};
                error.state = true;
                error.message = "Invald username or password !";
    
                this.setState({
                    error
                });   
            }
        });
    }
    else 
    {    
        e.preventDefault();
    }
    }

    render(){

        return (
            <div className="container-fluid">
                <br/>
                {this.state.error.state ? <Error output={this.state.error.message} /> :  ""   }
                <br/>
                <form onSubmit={this.submit}>
                <h1>Login</h1>
                <br />
                <div className="form-group">
                    <label htmlFor="LoginEmail">Email </label>
                    <input onChange={this.handleUpdate} type="email" name="email" className="form-control" id="LoginEmail" aria-describedby="emailHelp" placeholder="Enter Email" />
                </div>
                <div className="form-group">
                    <label htmlFor="LoginPassword">Password</label>
                    <input onChange={this.handleUpdate} type="password" name="password" className="form-control" id="LoginPassword" placeholder="Password" />
                </div>
                <div>
                    <button type="submit" className="btn btn-primary">Login</button>
                </div>
            </form>
            </div>
        )
    }
}