import { RecipeAllComponent } from "./recipe-all/recipe-all.component";
import { RecipeCreateComponent } from "./recipe-create/recipe-create.component";
import { RecipeDetailsComponent } from "./recipe-details/recipe-details.component";
import { RecipeEditComponent } from "./recipe-edit/recipe-edit.component";
import { RecipeStartComponent } from "./recipe-start/recipe-start.component";

import { NgModule } from "@angular/core";
import { Route, RouterModule } from "@angular/router";


let routes :Route[] = [
    { path : '', pathMatch:'full', component : RecipeStartComponent },
    { path : 'start', component : RecipeStartComponent },
    { path : 'all', component : RecipeAllComponent },
    { path : 'create', component : RecipeCreateComponent },
    { path : 'details/:id', component : RecipeDetailsComponent },
    { path : 'edit/:id', component : RecipeEditComponent },
    { path : '**', redirectTo : '/recipes/start'} //if we dont match any path we redirect to  '/recipes/start'
]

@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports :[ RouterModule ]
})
export class RecipeRoutingModule {}