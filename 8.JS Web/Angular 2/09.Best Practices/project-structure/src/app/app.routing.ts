import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginFormComponent } from './components/authentication/login-form/login-form.component';
import { RegisterFormComponent } from './components/authentication/register-form/register.form.component';
import { AuthGuard } from './core/guards/authentication/auth.guard';
import { BooksModule } from './components/books/books.module';


export const routes : Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', canActivate: [ AuthGuard ] , component: HomeComponent },
  { path: 'login', component: LoginFormComponent },
  { path: 'register', component: RegisterFormComponent }
  //{ path: 'books', loadChildren: () => BooksModule }
]