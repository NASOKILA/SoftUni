import { NgModule } from "@angular/core";
import { furnitureComponents } from ".";
import { FurntureService } from "./furnture.service";
import { FormsModule } from "@angular/forms";
import { FurnitureRoutingModule } from "./furniture-routing.module";
import { CommonModule } from "@angular/common";
import { NgxPaginationModule } from "ngx-pagination";

@NgModule({
    declarations : [
        ...furnitureComponents
    ],
    imports : [
        FormsModule,
        NgxPaginationModule,
        FurnitureRoutingModule,
        CommonModule,
        NgxPaginationModule    //pagination
    ],
    providers : [
        FurntureService
    ],
    exports : [
        CommonModule
    ]
})

export class FurnitureModule {}
