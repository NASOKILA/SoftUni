import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { authComponents } from './index';

@NgModule({
  declarations: [
    ...authComponents
  ],
  imports: [
    CommonModule
  ]
})
export class AuthModule {  }