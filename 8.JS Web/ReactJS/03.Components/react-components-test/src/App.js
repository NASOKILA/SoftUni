import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

//export Welcome like a default
import Welcome from './components/Welcome';

//export WelcomeFunction in an object becaouse its not a default.
import { WelcomeFunction } from './components/Welcome';

import Link from './components/Link';

import Sentences from './components/Sentences';

import Timer from './components/Timer';



class App extends Component {


  //This will trigger when we render something on the browser. 
  componentDidMount()
  {
    console.log('Rendered !!!')
  }

  render() {

    let SentencesObj = {
      first: "This is the first sentence.",
      second: "This is the second sentence.",
      third: "This is the third sentence."
    }

    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>


        {/*The function that acts like a componnt can be called in as a component and as a function*/}
        <Welcome />
        <Welcome title="Atanas" subtitle="Kambitov" />
        <Welcome title="React" subtitle="Framework" />
        {WelcomeFunction()}

        <br />
        <br />
        <p>We use the same component but with deferent properties !!!</p>
        <Link url="https://www.google.com/" name="Google" />
        <Link url="https://www.youtube.com/" name="YouTube" />
        <Link url="https://www.softuni.bg/" name="SoftUni" />

        <br />
        <br />

      {/*We can use the sentende object like this so the rendering will be easyer.*/}
        <Sentences {...SentencesObj}/>
        <br />
        <br />
        <Timer />



      </div>
    );
  }
}

export default App;
