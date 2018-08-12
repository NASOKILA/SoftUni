// All Modules in App
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { RouterModule } from "@angular/router";
import { ToastrModule } from 'ngx-toastr';
import { ServiceModule } from "./core/services/services.module";
import { AuthModule } from './components/authentication/auth.module';
import { SharedModule } from './components/shared/shared.module';
import { GuardsModule } from './core/guards/guards.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';

import { routes } from './app.routing';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { AuthGuard } from './core/guards/authentication/auth.guard';
import { LoginFormComponent } from './components/authentication/login-form/login-form.component';
import { RegisterFormComponent } from './components/authentication/register-form/register.form.component';
import { BooksModule } from './components/books/books.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', canActivate: [ AuthGuard ] , component: HomeComponent },
      { path: 'login', component: LoginFormComponent },
      { path: 'register', component: RegisterFormComponent },
      { path: 'books', loadChildren: () => BooksModule }
    ]),
    ServiceModule,
    AuthModule,
    SharedModule,
    GuardsModule
  ],
  providers: [ 
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    }  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
