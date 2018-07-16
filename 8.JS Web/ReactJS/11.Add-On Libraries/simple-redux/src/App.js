import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import logo from './logo.svg';
import './App.css';

import { addItemAction, removeItemAction } from './components/actions';
import { store } from './components/store';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">
          {
            
            store.getState().map(i => i + ", ")

          }</h1>
        </header>
        <button onClick={addItemAction}>Add Item</button>
        <button onClick={removeItemAction}>Remove Item</button>
          
      </div>
    );
  }
}

export default App;
 

store.subscribe(() => { 
  ReactDOM.render(<App />, document.getElementById('root'));
});

addItemAction();
//interval = setInterval(() => {
//}, 1000);
