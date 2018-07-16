import React, { Component } from 'react';
import Error from './Error';


export default class SignUpForm extends Component {

    constructor(props) {
        super(props);

        this.state = {
            form: {
                email: '',
                confirmEmail: '',
                name: '',
                password: '',
                confirmPassword : ''
            },
            error : {
                status : false,
                message: ''
            }
        }


        this.handleUpdate = this.handleUpdate.bind(this);
        this.isFormValid = this.isFormValid.bind(this);
        this.submit = this.submit.bind(this);
    }



    handleUpdate(e) {
        e.preventDefault();

        let key = e.target.name;
        let value = e.target.value;

        let newform = {};
        newform[key] = value;
        this.setState({
            form: Object.assign(this.state.form, newform)
            //Object.assign() helps us when working with objects, the structure of the major object stays the same.
        })

    }

    isFormValid() {

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
        else if (form.confirmEmail === "") {
            
            let error = {};
            error.state = true;
            error.message = "Confirm Email field is required !";

            this.setState({
                error
            });

            return false;
        }
        else if (form.name === "") {
            
            let error = {};
            error.state = true;
            error.message = "Username field is required !";

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
        else if (form.confirmPassword === "") {
            
            let error = {};
            error.state = true;
            error.message = "Confirm password field is required !";

            this.setState({
                error
            });

            return false;
        }
        else if (form.email !== form.confirmEmail) {
            
            let error = {};
            error.state = true;
            error.message = "Email fields do not match !";

            this.setState({
                error
            });

            return false;
        }
        else if (form.password !== form.confirmPassword) {
            
            let error = {};
            error.state = true;
            error.message = "Password fields do not match !";

            this.setState({
                error
            });

            return false;
        }
        



        return true;
    }


    submit(e) {

        if (this.isFormValid()) {

            //We have to send the data to http://localhost:5000/auth/signUp

            let form = {};
            form["email"] = this.state.form.email;
            form["name"] = this.state.form.name;
            form["password"] = this.state.form.password;
            
            fetch('http://localhost:5000/auth/signUp', {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(form)
            }
            )
                .then(data => data.json()).catch(err => console.log(err))
                .then(res => {
                    console.log(res)
                });
        }
        else 
        {
            e.preventDefault();
        }

    }


    render() {
        return (

            <div className="container-fluid">
            <br/>
            {this.state.error.state ? <Error output={this.state.error.message} /> :  ""   }
            <br/>
            <form onSubmit={this.submit}>
                <h1>Register</h1>
                <div className="form-group">
                    <label htmlFor="RegiterEmail">Email </label>
                    <input onChange={this.handleUpdate} type="email" name="email" className="form-control" id="RegiterEmail" aria-describedby="emailHelp" placeholder="Enter Email" />
                </div>
                <div className="form-group">
                    <label htmlFor="RegisterConfirmEmail">Confirm Email</label>
                    <input onChange={this.handleUpdate} type="email" name="confirmEmail" className="form-control" id="RegisterConfirmEmail" aria-describedby="emailHelp" placeholder="Confirm Email" />
                </div>
                <div className="form-group">
                    <label htmlFor="Username">User Name</label>
                    <input onChange={this.handleUpdate} type="text" name="name" className="form-control" id="Username" placeholder="Username" />
                </div>
                <div className="form-group">
                    <label htmlFor="RegisterPassword">Password</label>
                    <input onChange={this.handleUpdate} type="password" name="password" className="form-control" id="RegisterPassword" placeholder="Password" />
                </div>
                <div className="form-group">
                    <label htmlFor="RegisterConfirmPassword">Confirm Password</label>
                    <input onChange={this.handleUpdate} type="password" name="confirmPassword" className="form-control" id="RegisterConfirmPassword" placeholder="Confirm Password" />
                </div>
                <div>
                    <button type="submit" className="btn btn-primary">Register</button>
                </div>
            </form>
            </div>
        )
    }

}





