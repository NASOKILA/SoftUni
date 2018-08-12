import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { Course } from '../models/course.model';
import * as CourseActions from '../store/actions/course.actions';
import { AppState } from '../store/app.state';

@Component({
  selector: 'app-read',
  templateUrl: './read.component.html',
  styleUrls: ['./read.component.css']
})
export class ReadComponent implements OnInit {

  //here we use the model we created for courses
  //Redux returns Observables so our type must be Observable<Course[]>
  courses : Observable<Course[]>;

  //we pass our store so we can dispatch to it
  constructor(private store : Store<AppState>) {  }

  //we load all courses from redux before running
  //Redux returns Observables
  ngOnInit() {
    this.courses = this.store.select('courses');
  }

  //this function receives an integer which is the id of the course we want to delete
  delCourse(index) {
    this.store.dispatch(new CourseActions.RemoveCourse(index));
  }

}
