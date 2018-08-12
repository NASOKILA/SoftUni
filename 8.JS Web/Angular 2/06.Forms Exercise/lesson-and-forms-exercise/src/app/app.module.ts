import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HighlightDirective } from './directives/highlight.directive';
import { Capitalize } from './pipes/capitalize.pipe';
import { NavigationComponent } from './navigation/navigation.component';
import { LoginComponent } from '../authentication/login/login.component';
import { RegisterComponent } from '../authentication/register/register.component';
import { AppRoutingModule } from './app.routing';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LessonComponent } from './lesson/lesson.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpHeaders, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AuthService } from '../authentication/auth.service';
import { TokenInterceptor } from './interceptors/token.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    HighlightDirective,
    Capitalize,
    NavigationComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    LessonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpModule
  ],
  providers: [AuthService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi : true
  }], //we provide our service to be used even outside this component
  bootstrap: [AppComponent]
})
export class AppModule { }
