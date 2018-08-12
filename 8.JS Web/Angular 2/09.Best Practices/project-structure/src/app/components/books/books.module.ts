import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { bookComponents } from "./index";
import { bookRoutes } from './books.routing';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(bookRoutes)
  ],
  declarations: [
    ...bookComponents
  ]
})
export class BooksModule {  }