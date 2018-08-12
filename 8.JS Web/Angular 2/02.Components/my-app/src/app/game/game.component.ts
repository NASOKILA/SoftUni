import { Component, OnInit } from '@angular/core';
import { Game } from '../../app/game';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  
  public games : Array<Game>;
  public isShown : Boolean;
  public myName : String = "";
  
  constructor() {

    let kayhudo = new Game(1, "Kayhudo", "https://vignette.wikia.nocookie.net/kaijudo/images/c/cc/Kaijudo_Online_Game_4.jpg/revision/latest?cb=20120615045106");
    let burning = new Game(2, "Burning", "http://ozogames.com/images/burning-wheels-backyard-online-game.jpeg");
    this.games = [ kayhudo, burning ];
   }

  ngOnInit() {
  }

  //We create the function that we passed and it receives a string
  notifyMe(notification:String){
    console.log(notification);
  }

  showName(name:string){
    this.myName = name;
    console.log(this.myName);
  }
  
  showContacts() {
   this.isShown = !this.isShown;

   /*if(this.isShown === true)
      this.isShown = false;
    else
      this.isShown = true;*/
  }

}
