import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';

import { ComixAllComponent } from './components/comix/comix-all/comix-all.component';
import { ComixCreateComponent } from './components/comix/comix-create/comix-create.component';
import { ComixDetailsComponent } from './components/comix/comix-details/comix-details.component';
import { ComixEditComponent } from './components/comix/comix-edit/comix-edit.component';
import { ComixDeleteComponent } from './components/comix/comix-delete/comix-delete.component';
import { OrderConfirmComponent } from './components/order/order-confirm/order-confirm.component';
import { OrderFinishComponent } from './components/order/order-finish/order-finish.component';
import { HeaderComponent } from './components/common/header/header.component';
import { FooterComponent } from './components/common/footer/footer.component';
import { HomeComponent } from './components/common/home/home.component';
import { OrderMyComponent } from './components/order/order-my/order-my.component';
import { OrderAllComponent } from './components/order/order-all/order-all.component';
import { AppRoutingModule } from './app.routing.module';
import { AuthService } from './components/auth/auth.service';
import { ProfileComponent } from './components/user/profile/profile.component';
import { UserAllComponent } from './components/user/user-all/user-all.component';
import { RequesterService } from './app.requester';
import { ComixService } from './components/comix/comix.service';
import { UserService } from './components/user/user.service';
import { CommentsService } from './components/comix/comments.service';
import { UserDetailsComponent } from './components/user/user-details/user-details.component';
import { OrderService } from './components/order/order.service';
import { OrderDetailsComponent } from './components/order/order-details/order-details.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { ErrorComponent } from './components/common/error/error.component';
import { UserchangeComponent } from './components/user/userchange/userchange.component';
import { ChangepasswordComponent } from './components/user/changepassword/changepassword.component'
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { CommonModule } from '../../node_modules/@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    ComixAllComponent,
    ComixCreateComponent,
    ComixDetailsComponent,
    ComixEditComponent,
    ComixDeleteComponent,
    LoginComponent,
    RegisterComponent,
    OrderConfirmComponent,
    OrderFinishComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    OrderMyComponent,
    OrderAllComponent,
    ProfileComponent,
    UserAllComponent,
    UserDetailsComponent,
    OrderDetailsComponent,
    ErrorComponent,
    UserchangeComponent,
    ChangepasswordComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    NgxPaginationModule,
    FontAwesomeModule,
    AngularFontAwesomeModule,
  ],
  providers: [
    AuthService,
    RequesterService,
    ComixService,
    CommentsService,
    UserService,
    OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }