import { NgModule } from "@angular/core";
import { authComponents } from ".";
import { AuthService } from "./auth.service";
import { FormsModule } from "@angular/forms";

@NgModule({
    declarations : [
        ...authComponents
    ],
    imports : [
        FormsModule
    ],
    providers : [
        AuthService
    ]
})

export class AuthModule {}
