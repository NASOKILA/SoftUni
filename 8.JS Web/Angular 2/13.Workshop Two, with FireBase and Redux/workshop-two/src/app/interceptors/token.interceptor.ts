import {
    HttpHandler,
    HttpEvent,
    HttpRequest,
    HttpInterceptor
} from '@angular/common/http';

import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';
import { AuthService } from '../components/auth/auth.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor(private authService : AuthService){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        //we append the token to each request if we have it
        const token = this.authService.getToken();
        
        if(token) {
            req = req.clone({
                url : `${req.url}?auth=${token}`
            })
        }
        
        return next.handle(req);
    }

}