import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.css'
import logo from './logo.svg';
import RegisterForm from './components/SignUpForm';
import LoginForm from './components/LoginForm';
import CreatePokemonForm from './components/CreatePokemonForm';
import './App.css';

class App extends Component {
  
constructor(props){
  super(props)

  let route = "register";

  if(localStorage.getItem('token'))
    route = "loggedIn";

  this.state = {
    route
  }

  this.showAppropriateComponent = this.showAppropriateComponent.bind(this)
  this.switchForm = this.switchForm.bind(this)

}

  showAppropriateComponent(){ 
    
    
    if(this.state.route == 'loggedIn'){
      return <CreatePokemonForm/>
    }
    else if(this.state.route === 'login'){
      return <LoginForm/>
    } 
    else if(this.state.route === 'register'){
      return <RegisterForm/>      
    }

    return <RegisterForm/>  
  }

  switchForm(){

    if(this.state.route === "register")
    {
        this.setState({
            route: 'login'
        });
    }
    else if(this.state.route === "login"){

      this.setState({
        route: 'register'
      });
    }
    else {
      this.setState({
        route: 'register'
      });
    }
}


  render() {
    return (
          <div className="App">
          <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
            <br/>
            <button style={{display: this.state.route === "loggedIn" ? "none" : ""}} onClick={this.switchForm} >Switch Form</button>
            <br/>
            
            
            {this.showAppropriateComponent()}
            <br/>
            <br/>
            <br/>
            
          </div>
            );
          }
        }
        
        export default App;
