import { ADD_ITEM, REMOVE_ITEM } from './constants';

let interval = null; 
let counter = 0;


export const reducer = (state, action) => {
  
  if(action.type === ADD_ITEM){
    counter++;
    return state.concat([counter]);
  }
  else if(action.type === REMOVE_ITEM){
    
    console.log(state);
    counter--;
    return state.splice(0, state.length-1);
  }

  return state;
}

