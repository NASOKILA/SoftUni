import { Component, OnInit } from '@angular/core';
import * as firebase from 'Firebase';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit {
  title = 'workshop-one';
  
  ngOnInit() : void {
    firebase.initializeApp({
      apiKey: "AIzaSyAuIS__e_4nsOs1HvRCf4oIV5uIncHCXNE",
      authDomain: "recipes-app-72484.firebaseapp.com"
    })
  }
}
