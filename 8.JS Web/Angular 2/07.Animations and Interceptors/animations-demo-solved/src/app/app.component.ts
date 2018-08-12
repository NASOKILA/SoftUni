import { Component } from '@angular/core';
import { appAnimations } from './app.animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  animations: appAnimations
})
export class AppComponent {

  //we have two states for the two sqares
  state = "normal";
  wildState = "normal";
  list = ['Milk', 'Sugar', 'Bread'];

    onAdd(item) {
      this.list.push(item);
    }

    onDelete(item) {
      this.list.splice(this.list.indexOf(item), 1);
    }

    //we change the state on each click, it can be normal or ighlited
    onAnimate() {
      this.state == "normal" 
       ?  this.state = "highlighted" 
       : this.state = "normal"

       this.wildState == "normal" 
       ?  this.wildState = "highlighted" 
       : this.wildState = "normal"
    }

    //we have a third state for the second sqare
    onShrink() {
      this.wildState = "shrunken";
    }

    animationStart(event) {
      console.log(event);
    }

    animationEnd(event) {
      console.log(event);
    }
}
