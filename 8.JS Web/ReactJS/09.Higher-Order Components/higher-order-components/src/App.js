
import React, { Component } from 'react';
import logo from './logo.svg';
import Home from './components/Home';
import Second from './components/Second';
import ComponentWithData from './components/ComponentWithData';
import './App.css';

const request = function() {
  return new Promise((resolve, reject) => {
    
    setTimeout(() => {

      resolve([
        {id:'1', name:'Nasko'},
        {id:'2', name:'Petre'},
        {id:'3', name:'Asi'},
        {id:'4', name:'Kosio'},
      ])
      
    },2000);

  })
}

class App extends Component {
  
  render() {



    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>

        <Second />

        {/*Messges dont work if we dont pass then thrue the withLogging function.*/}
        <Home message="Hello home message!"/>
        <ComponentWithData request={request}/>
      
      </div>
    );
  }
}

export default App;
