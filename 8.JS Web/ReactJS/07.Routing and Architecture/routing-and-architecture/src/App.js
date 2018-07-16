import React, { Component } from 'react';
import logo from './logo.svg';

import Navigation from './components/Navigation';
import Footer from './components/Footer';

import AddRouter from './components/AddRouter';


import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <Navigation />

        <AddRouter />

        <Footer />
      </div>
    );
  }
}

export default App;
