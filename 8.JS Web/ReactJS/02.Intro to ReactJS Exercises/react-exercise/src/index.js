

//import react DOM
import ReactDOM from 'react-dom';

//import the css file
import './index.css';

//import the app
import App from './App';

//provides faster work proccess and loading,  dynamic updating
import registerServiceWorker from './registerServiceWorker';

//we import the app and render it in the element with id 'root' !!!
ReactDOM.render(App(), document.getElementById('root'));
registerServiceWorker();

const rerender = ReactDOM.render;

export default rerender;
