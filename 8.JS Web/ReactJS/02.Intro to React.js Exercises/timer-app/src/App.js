import React from 'react';
import logo from './logo.svg';
import './App.css';
import rerender from './index';


let currentTime = new Date(Date.now()).toLocaleTimeString();
let counter = "00:00:00";
let seconds = 0;
let minutes = 0;
let hours = 0;

  setInterval(() => {

    seconds++; 

    if(seconds === 60)
    {
      minutes++;
      seconds = 0;
    }

    if(minutes === 60)
    {
      hours++;
      minutes = 0;
    }

    let secondsToString = seconds.toString().length < 2 
    ? "0" + seconds 
    : seconds
    
    let minutesToString = minutes.toString().length < 2 
    ? "0" + minutes 
    : minutes

    let hoursToString = hours.toString().length < 2 
    ? "0" + hours 
    : hours
    
    counter = `${secondsToString}:${minutesToString}:${hoursToString}`;
    
    console.log(counter);

    currentTime = new Date(Date.now()).toLocaleTimeString();
    console.log(currentTime);
    
    //every second the time will be updated 
    rerender(Timer(), document.getElementById('root'));
  }, 1000)
  
const Timer = () => (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
        </header>
          <h1>Current Time</h1>
          <h1>{currentTime}</h1>
          <hr/>
        <h1>Counter</h1>
          <h1>{counter}</h1>

      </div>
    );

export default Timer;
