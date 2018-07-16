import React from 'react';
import ReactDOM from 'react-dom';

//import the BrowserRouter
import {BrowserRouter} from 'react-router-dom'
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(
    //we wrap the App component around the BrowserRouterCoomponent so it can work.
<BrowserRouter>
<App />
</BrowserRouter>

, document.getElementById('root'));
registerServiceWorker();
