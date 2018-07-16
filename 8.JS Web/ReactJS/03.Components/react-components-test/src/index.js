import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

let rerender = ReactDOM.render;
ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();

export default rerender;