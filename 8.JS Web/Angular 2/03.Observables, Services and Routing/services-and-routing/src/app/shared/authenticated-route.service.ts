
import { CanActivate } from "@angular/router";
import { Injectable } from "@angular/core";

//class implements CanActivate
//we mark this function as injectable
@Injectable()
export class AuthenticatedRoute implements CanActivate {

    
    canActivate(){

        //logic goes here

        //if(this.userService.isAuthenticated) {return true;}else {return false;}
 
        
        //if we return true than we are authenticated
        return false;
    }
}