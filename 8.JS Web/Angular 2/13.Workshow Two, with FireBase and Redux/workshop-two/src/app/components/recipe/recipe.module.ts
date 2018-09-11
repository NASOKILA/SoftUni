import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RecipeAllComponent } from './recipe-all/recipe-all.component';
import { RecipeCreateComponent } from './recipe-create/recipe-create.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';
import { RecipeEditComponent } from './recipe-edit/recipe-edit.component';
import { RecipeStartComponent } from './recipe-start/recipe-start.component';
import { RecipeRoutingModule } from './recipe-routing.module';

@NgModule({
    declarations: [
        RecipeAllComponent,
        RecipeCreateComponent,
        RecipeDetailsComponent,
        RecipeEditComponent,
        RecipeStartComponent
    ],
    imports: [
        FormsModule,
        CommonModule,
        RecipeRoutingModule
    ],
    exports: []
})

export class RecipeModule { }