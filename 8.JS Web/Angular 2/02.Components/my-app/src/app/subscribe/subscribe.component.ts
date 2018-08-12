import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Game } from '../../app/game';
//w import Input as wel

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})

export class SubscribeComponent implements OnInit {
  
  //we create a subGame Input of type Game
  @Input('subGame') subGame:Game;

  //we create an Output notifiction EventEmmitter<String>(); of type String
  @Output() notification = new EventEmitter<String>();

  public gameIdShow:Boolean = false;
  
  constructor() { }

  ngOnInit() {
  }
  

  //function to show notification subscription
  showSubscription(){
    console.log(`The ID is ${this.subGame.id}`);

    //we have to pass it a string to the emit() function
    this.notification.emit("Subscription success !");
  }

  //function to show gameId
  showGameId(){
    this.gameIdShow = !this.gameIdShow;
  }
}
