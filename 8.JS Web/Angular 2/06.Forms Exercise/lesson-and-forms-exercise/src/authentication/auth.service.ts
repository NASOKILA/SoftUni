
import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { LoginModel } from "./models/login.model";
import { RegisterModel } from "./models/register.model";


const appKey : string = "kid_rJuhpTmSQ";
const appSecret : string = "416f44c08dc14aed88d60ff532356490";
const registerUrl : string = `https://baas.kinvey.com/user/${appKey}`;
const loginUrl : string = `https://baas.kinvey.com/user/${appKey}/login`;
const logoutUrl : string = `https://baas.kinvey.com/user/${appKey}/_logout`;

@Injectable()
export class AuthService {

    private currentAuthtoken : string;
    private currentUsername : string;
    
    constructor(private http : HttpClient){}



    //WE DONT NEEED THIS FUNCTION ANYMORE, FOR THE HEADERS WE MADE AN INTERCEPTOR
    /*
    //this function creates the authentication, it can be Basic (when we login or register), Kinvey (when we are logged in)
    private createAuthHeaders(type : string) : HttpHeaders {
        if(type === "Basic"){
            return  new HttpHeaders({
                "Authorization" : `Basic ${btoa(`${appKey}:${appSecret}`)}`,
                "Content-Type" : 'application/json'
            })
        } else {
            return new HttpHeaders({
                "Authorization" : `Kinvey ${localStorage.getItem("authtoken")}`,
                "Content-Type" : "application/json"
            })
        }
    }*/

    public login(loginModel : LoginModel){
        return this.http.post(
            loginUrl, 
            JSON.stringify(loginModel), 
            { /*headers : this.createAuthHeaders("Basic") */}
            //we use the Intercepror for the headers, we dont need to set them manually anymora
        );
    }

    public register(registerModel : RegisterModel){
        return this.http.post(
            registerUrl, 
            JSON.stringify(registerModel), 
            { /*headers : this.createAuthHeaders("Basic") */}
            //we use the Intercepror for the headers, we dont need to set them manually anymora
        );
    }

    public logout() {
        return this.http.post(
            logoutUrl,
            {},
            { /*headers : this.createAuthHeaders("Kinvey") */}                
            //we use the Intercepror for the headers, we dont need to set them manually anymora       
        );
    }

    //getter and setter for the authtoken field
    get authtoken(){
        return this.currentAuthtoken;
    }
    set authtoken(newAuthtoken : string) {
        this.currentAuthtoken = newAuthtoken; 
    }

    //getter and setter for the username field
    get username(){
        return this.currentUsername;
    }
    set username(newUsername : string) {
        this.currentUsername = newUsername; 
    }

    //Guards:
    checkIfLoggedIn(){
        let loggedIn = this.currentAuthtoken === localStorage.getItem('authtoken');
        //console.log("LOGGEDIN " + loggedIn)
        return loggedIn; 
    }
}
