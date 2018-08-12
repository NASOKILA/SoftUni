import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app.routing';

import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component';

import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { CustomFormsModule } from 'ng2-validation';
import { AuthModule } from './authentication/auth.module';
import { FurnitureModule } from './furniture/furniture.module';
import { FurnitureEditComponent } from './furniture/furniture-edit/furniture-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    HomeComponent
  ],
  imports: [
    AuthModule,
    FurnitureModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule, // import BrowserAnimationsModule 
    ToastrModule.forRoot(), //import ToastrModule
    CustomFormsModule 
  ],
  providers: [ 
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
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }