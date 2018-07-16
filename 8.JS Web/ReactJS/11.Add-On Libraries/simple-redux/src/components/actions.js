
//import { ADD_ITEM, REMOVE_ITEM } from './components/constants';
import { store }  from './store';


const ADD_ITEM = "ADD_ITEM";
const REMOVE_ITEM = "REMOVE_ITEM";


const addItemAction = () => {
    store.dispatch({
      type: ADD_ITEM
    });
  }
  
  const removeItemAction = () => {
    store.dispatch({
      type: REMOVE_ITEM
    });
  }

export {
    addItemAction,
    removeItemAction
}