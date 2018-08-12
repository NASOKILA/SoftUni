
//To create a module we need 'NgModule'
import { NgModule } from '@angular/core';

//to use @ngIf() @ngFor we need 'CommonMoudle'
import { CommonModule } from '@angular/common';

//to use clientModule to fetch data we need
import { HttpClientModule } from '@angular/common/http';

import { HomeComponent } from './home.component';

@NgModule({
    imports:[CommonModule, HttpClientModule],
    exports: [HomeComponent],  //to use the HomeComponent outside we need to export it otherwise there is an ERROR
    declarations: [HomeComponent],
    providers: []
})

export class HomeModule { }

