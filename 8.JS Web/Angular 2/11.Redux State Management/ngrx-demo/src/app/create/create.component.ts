import { Component, OnInit } from '@angular/core';

//we need the Store, our state and the actions
import { Store } from '@ngrx/store';
import { AppState } from '../store/app.state';
import * as CourseActions from '../store/actions/course.actions';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  //we pass the store and it ha to be of type AppState which is the type of out app.state.ts file !!!
  constructor(private store : Store<AppState>) { }

  //this component uses one function for adding a course which receives a name and url
  //we dispatch it to the store so the reduser can handle it.
  addCourse(name : string, url : string) {
    this.store.dispatch(new CourseActions.AddCourse({name : name, url: url})); 
  }

  ngOnInit() {
  }

}
