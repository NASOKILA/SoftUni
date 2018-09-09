import { NgModule } from '@angular/core'
import { RouterModule } from '@angular/router'
import { SigninComponent } from './components/auth/signin/signin.component';
import { SignupComponent } from './components/auth/signup/signup.component';
import { AuthGuard } from './components/auth/auth.guard';
import { RecipeModule } from './components/recipe/recipe.module';
import { RecipeGuard } from './components/recipe/recipe.guard';

const routes = [
    {
        path: 'auth', children: [
            { path: 'signin', component: SigninComponent },
            { path: 'signup', component: SignupComponent }
        ], canActivate : [RecipeGuard]
    },
    {
        path: 'recipes',
        loadChildren: () => RecipeModule,  //This is lazy loading 
        canActivate: [AuthGuard]    //To access all these routes we have to pass true the guard
    }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { };
