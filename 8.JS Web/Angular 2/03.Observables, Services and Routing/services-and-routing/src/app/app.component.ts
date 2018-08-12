import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'services-and-routing';
}

class Engine {

  public model : String;
  public type : String;
  
  constructor(model : String, type : String){
    this.model = model;
    this.type = type;
  }
}


class Car {
  
  private engine : Engine;
  public make : string;
  public model : string;
  
  constructor(make : string, model : string, engine : Engine){
    this.make = make;
    this.model = model;
    this.engine = engine;
  }
}


//Engines
let bigEngine = new Engine("w15", "Diesel");
let middleEngine = new Engine("w9", "Gasoline");
let smallEngine = new Engine("w3", "Gasoline");

//If we dont pass the engine thrue the constructor, these cars will have equal engines
//Cars
let bmw = new Car("BMW", "X5", bigEngine);
let mercedes = new Car("Mercedes", "C230", middleEngine);
let audi = new Car("Audi", "TT", smallEngine);

console.log(bmw);
console.log(mercedes);
console.log(audi);