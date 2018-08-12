import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app.routing';

import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { SigninComponent } from './authentication/signin/signin.component';
import { SignupComponent } from './authentication/signup/signup.component';
import { HomeComponent } from './home/home.component';
import { AuthService } from './authentication/auth.service';

import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AllFurnitureComponent } from './furniture/all-furniture/all-furniture.component';
import { CreateFurnitureComponent } from './furniture/create-furniture/create-furniture.component';
import { FurnitureDetailsComponent } from './furniture/furniture-details/furniture-details.component';
import { MyFurnitureComponent } from './furniture/my-furniture/my-furniture.component';
import { FurntureService } from './furniture/furnture.service';

import { CustomFormsModule } from 'ng2-validation';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    SigninComponent,
    SignupComponent,
    HomeComponent,
    AllFurnitureComponent,
    CreateFurnitureComponent,
    FurnitureDetailsComponent,
    MyFurnitureComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule, // import BrowserAnimationsModule 
    ToastrModule.forRoot(), //import ToastrModule
    CustomFormsModule 
  ],
  providers: [ 
    AuthService,
    {//import both interceptors
      provide : HTTP_INTERCEPTORS,
      useClass : JwtInterceptor,
      multi : true
    },
    {
      provide : HTTP_INTERCEPTORS,
      useClass : ErrorInterceptor,
      multi : true
    },
    FurntureService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }