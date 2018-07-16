import { createStore } from 'redux';
import { reducer } from './reducer';


const initialStore = [];
const store = createStore(reducer, initialStore, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());
export { store }



