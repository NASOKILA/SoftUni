import { Action } from '@ngrx/store';
import { Course } from '../../models/course.model';


//an action needs to have a type which describ what is happening
//these constants rapresent what is hapening, we will use them later in the components
export const ADD_COURSE = '[COURSE] Add';
export const REMOVE_COURSE = '[COURSE] Remove';


  //this is one action it implements the Action class from @ngrx/store, it has:
  //unique action type
  //payload are data which runs with the app, in this case we are adding a course so we receive 
  //data of type Course which is the model that we created earlyer
export class AddCourse implements Action {
  readonly type: string = ADD_COURSE;

  constructor(public payload : Course) {  }
}

//this is another action
//here we are removing a course so we receive a number thru the coonstructor
export class RemoveCourse implements Action {
  readonly type: string = REMOVE_COURSE;

  constructor(public payload : number) { }
}


//export type: 
//We can use this to declare that we can put into 'Actions' only elements of type AddCourse or RemoveCourse !!!
export type Actions = AddCourse | RemoveCourse;