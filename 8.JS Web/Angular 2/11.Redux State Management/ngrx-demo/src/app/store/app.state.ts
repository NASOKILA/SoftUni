

import { Course } from '../models/course.model';

//the state is the courses array and it is a readonly property
export interface AppState {
   readonly courses: Course[]
}