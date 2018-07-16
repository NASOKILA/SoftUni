import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Test from './components/Test';
import RegisterForm from './components/RegisterForm';
import Container from './components/Container';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>

        <div>
          <Test alertMessage="Alert Message Here !"/> 
          <br/>
          <br/>
          <br/>
          <RegisterForm />
          <br/>
          <br/>
          <br/>
          <Container>
            <h1>Hello World</h1>
            <h2>From Nasko</h2>
          </Container>
        </div>

        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
      </div>
    );
  }
}

export default App;
