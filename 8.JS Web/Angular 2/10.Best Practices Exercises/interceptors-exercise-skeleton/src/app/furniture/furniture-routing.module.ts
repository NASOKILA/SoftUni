import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CreateFurnitureComponent } from "./create-furniture/create-furniture.component";
import { AllFurnitureComponent } from "./all-furniture/all-furniture.component";
import { FurnitureDetailsComponent } from "./furniture-details/furniture-details.component";
import { MyFurnitureComponent } from "./my-furniture/my-furniture.component";

const furnitureRoutes : Routes = [
    { path: 'create', component: CreateFurnitureComponent },
    { path: 'all', component: AllFurnitureComponent },
    { path: 'details/:id', component: FurnitureDetailsComponent },
    { path: 'mine', component: MyFurnitureComponent }
]

@NgModule({
    imports : [
        RouterModule.forChild(furnitureRoutes)
    ],
    exports : [ 
        RouterModule
    ]

})
export class FurnitureRoutingModule { }