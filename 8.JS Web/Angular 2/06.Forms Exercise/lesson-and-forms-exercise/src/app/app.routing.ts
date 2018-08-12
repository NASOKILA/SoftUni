
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router"
import { LoginComponent } from "../authentication/login/login.component";
import { RegisterComponent } from "../authentication/register/register.component";
import { HomeComponent } from "./home/home.component";
import { LessonComponent } from "./lesson/lesson.component";
import { AuthGuard } from "./guards/auth.guard";

const routes : Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'home' },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] }, // we use our guard 
    { path: 'lesson', component: LessonComponent }, 
    { path: 'login', component: LoginComponent }, 
    { path: 'register', component: RegisterComponent }
]

//we declare the module, import and export it
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}