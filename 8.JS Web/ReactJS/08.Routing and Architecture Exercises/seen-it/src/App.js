import React, { Component } from 'react'
  import logo from './logo.svg';

import Home from  './components/home/Home';

import Header from  './components/common/Header';
import { Route } from  'react-router-dom'
import './styles/site.css';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <Header />
        <Route path="/" exact component={Home}/>
      </div>
    );
  }
}

export default App;
