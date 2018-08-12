import { BrowserModule } from '@angular/platform-browser';

//To use ngForms we have to import this too
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { GameComponent } from './game/game.component';
import { SubscribeComponent } from './subscribe/subscribe.component';

@NgModule({
  declarations: [
    AppComponent,
    GameComponent,
    SubscribeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
