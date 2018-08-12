import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'animations-and-interceptors';

  private list : string[];
  constructor(){
    this.list = ["Banana", "Orange", "Apple"];
  }

  onAdd(item : string){
    this.list.push(item);
  }

  onDelete(item){
    this.list.slice(this.list.indexOf(item), 1);
  }
}
