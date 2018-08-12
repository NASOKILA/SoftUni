import {
    HttpResponse,
    HttpRequest,
    HttpHandler,
    HttpInterceptor,
    HttpEventType,
    HttpEvent
} from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators'; //it changes the observable before we subscribe to it
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
    

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    

    constructor(private toastr : ToastrService,
        private router : Router){} 

    intercept(req: HttpRequest<any>, next: HttpHandler)
    : Observable<HttpEvent<any>> {
        
        //if we have the token in the localstorage we register it
        //we take the current user from the local storage, it contains the username and token
        let currentUser = JSON.parse(localStorage.getItem("currentUser"));

        //if we have the user and the token
        if(currentUser && currentUser.token){
            
            //we append the token to the request
            req = req.clone({
                setHeaders : {
                    'Authorization' : `Bearer ${currentUser.token}`
                }
            })    
        }
        
        
        //we need to catch the response and save the user's token into the localStorage if its missing
        //we use the tap operator which 
        return next.handle(req)
            .pipe(
                tap((res : any) => {
                    
                    //if the response is of type HttpResponse && it contains a token 
                    if(res instanceof HttpResponse && res.body.token) {
                        //we save the user to the localStorage
                        let user = res.body;
                        this.save(user);
                    }

                    //if we register successfully, we will have a success property if that happens
                    //we show the message and we redirect
                    if(res instanceof HttpResponse && res.body.success && res.url.endsWith("signup")){
                        this.toastr.success(res.body.message, "success");
                        this.router.navigate(["/signin"]);                    
                    }

                    //if we login successfully we show the messge and we redirect 
                    if(res instanceof HttpResponse && res.body.success && res.url.endsWith("login")){
                        this.toastr.success(res.body.message, "success");
                        this.router.navigate(["/furniture/all"]);
                    }

                    if(res instanceof HttpResponse && res.body.success && res.url.endsWith("create")){
                        this.toastr.success(res.body.message, "success");
                        this.router.navigate(["/furniture/all"]);
                    }
                    
                })
            );
    }

    save(user) {
        localStorage.setItem("currentUser", JSON.stringify({
            "username" : user.user.name,
            "token" : user.token
        }));
    }
}

