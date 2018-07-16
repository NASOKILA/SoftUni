 import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { Provider } from 'react-redux'
import { createStore } from 'redux'

let initialState = [];

let counter = 0;
const rootReducer = (state, action) => {
  
    
    if(action.type === "ADD_ITEM"){
      counter++;
      return state.concat([counter]);
    }
    else if(action.type === "REMOVE_ITEM"){
      
      console.log(state);
      return state.splice(0, state.length-1);
    }
  
    return state;
  }
  

let store = createStore(rootReducer, initialState);

//import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(
    <Provider store={store}>
        <App /> 
    </Provider>
    , document.getElementById('root'));

//registerServiceWorker();
