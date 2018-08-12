import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

//To use this class we have to mark it as Injectable:
@Injectable()

//Then we have to register it into app.modules.ts; in the Providers array


export class HomeService {
    
    constructor(private httpClient: HttpClient){}

    getData():string {
        return "Hello from the service which fetches data from server!";
    }

    //http clint can work with data, post, get put and more
    getGitHubProfile(profile:string){
        const url = `https://api.github.com/users/${profile}`;
        
        //httpClient returns observable therefore we have to parse it into an object
        return this.httpClient
            .get<Object>(url);
    }

}
