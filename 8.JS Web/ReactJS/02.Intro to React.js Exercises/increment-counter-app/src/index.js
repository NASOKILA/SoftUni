import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(App(), document.getElementById('root'));
registerServiceWorker();


const rerender = ReactDOM.render;
//trqbva da exportnem ReactDOM.render() funkciqta za da q polzvame v App.js za da updeitvame.
export default rerender;
