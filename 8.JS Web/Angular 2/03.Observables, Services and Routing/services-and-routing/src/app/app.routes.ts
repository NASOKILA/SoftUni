
//this class will hold all the routes

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { AuthenticatedRoute } from './shared/authenticated-route.service';

const routes : Routes = [
    { path: 'home', component: HomeComponent },
    { path: '', component: HomeComponent },
    { path: 'about', component: AboutComponent },

    //we can use the route to create routes in the following way
    { path: 'courses', children : [
        { path: 'details', component: AboutComponent }, //courses/details
        { path: 'create', component: AboutComponent }, //courses/create
        { path: 'edit/:id', component: AboutComponent }, //courses/edit/5
    ] },

    { 
        path: 'contact/:name/:id', 
        component: ContactComponent,
        canActivate: [AuthenticatedRoute] //this is how we make it for authenticated users 
    }
];

//we have to mark this as a module with the routes
@NgModule({
    imports:[RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: [AuthenticatedRoute] //to use it we have to mark in the providers array
})

export class AppRoutesModule {}
