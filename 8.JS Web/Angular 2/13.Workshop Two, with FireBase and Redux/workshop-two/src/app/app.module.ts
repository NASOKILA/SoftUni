import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/common/header/header.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app.routing.module';
import { AuthService } from './components/auth/auth.service';
import { RecipeService } from './components/recipe/recipe.service';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { AuthModule } from './components/auth/auth.module';
import { RecipeModule } from './components/recipe/recipe.module';
import { StoreModule } from '../../node_modules/@ngrx/store';
import { appReducers } from './store/app.reducers';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    FormsModule,
    StoreModule.forRoot(appReducers), //here we specify for which properti which reducer to be used
    AppRoutingModule,
    HttpClientModule,
    HttpModule,
    BrowserModule,
    ToastrModule.forRoot(), //we add the css in the angular.json file
    BrowserAnimationsModule,

    RecipeModule, //I created this module
    AuthModule    //I created this module
  ],
  providers: [
    AuthService, 
    RecipeService,
    {                  //interceptor
      provide : HTTP_INTERCEPTORS,
      useClass : TokenInterceptor,
      multi : true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
