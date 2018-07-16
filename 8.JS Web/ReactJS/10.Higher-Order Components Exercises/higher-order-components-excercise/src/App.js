import React, { Component } from 'react';
import logo from './logo.svg';

import Article from './components/Article';
import Register from './components/Register';
import Navigation from './components/Navigation';
import CatchError from './components/ErrorCatch';
import BoundForm from './components/boundForm';

import './App.css';

function onSubmit(e, data){
  console.log(data);
}

class App extends Component {
  render() {
    return (
      <div className="App">
      <CatchError>

        <Article />
            <Register />
          
        <Navigation />
        
        <BoundForm onSubmit={onSubmit}>
          <h1>Login</h1>
          Username:
          <input type="text" name="username"/>
          Password:
          <input type="password" name="password"/>
          <input value="Login" type="submit"/>
        </BoundForm>


        <BoundForm onSubmit={onSubmit}>
        <h1>Register</h1>
          Name:
          <input type="text" name="name"/>
          Email:
          <input type="email" name="email"/>
          Password:
          <input type="password" name="password"/>
          Confirm Password:
          <input type="password" name="confirmpassword"/>
          <input value="Register" type="submit"/>
        </BoundForm>

      </CatchError>

      </div>
    );
  }
}

export default App;
