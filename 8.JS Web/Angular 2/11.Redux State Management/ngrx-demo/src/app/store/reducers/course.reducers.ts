import { Course } from '../../models/course.model';
import * as CourseActions from '../actions/course.actions';


const initialState : Course = {
  name: 'Angular Fundamentals July 2018',
  url: 'https://softuni.bg/trainings/2037/angular-fundamentals-july-2018'
}


function removeTutorial(state, action : CourseActions.RemoveCourse) {
  const itemToRemove = state[action.payload];
  return [...state.filter(a => a !== itemToRemove)];
}


//the reducer is a function which receives a state and an action
//the state cannot be null so we initially set it to an array with one object 'initialState' !!!!!!!!!!!!
export function reducer(
  state : Course[] = [initialState], 
  action: CourseActions.Actions) {
  
  //we switch case the type of the action that we received
  switch(action.type) {
    case CourseActions.ADD_COURSE:

      return [...state, action.payload]; //we return a new state with 
    case CourseActions.REMOVE_COURSE:
    
      return removeTutorial(state, action as CourseActions.RemoveCourse);
      default: // if we dont have that action in 'actions' we just return the state the way we received it.
      return state;
  }
}
