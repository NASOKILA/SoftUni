import React from 'react';
import logo from './logo.svg';
import './App.css';

//we import the ReactDOM.render() function so we can updata our counter
import rerender from './index';

    
let number = 0;
    
const Increase = () => {
  number = number + 1;

  //we use the function to rerender the counter
  rerender(App(), document.getElementById('root'));
}  

//we make it a function which returns that html
const App = () => (
     
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <span>{number}</span><br/>
        <button onClick={Increase}>Increase</button>
      </div>
    );  

export default App;
