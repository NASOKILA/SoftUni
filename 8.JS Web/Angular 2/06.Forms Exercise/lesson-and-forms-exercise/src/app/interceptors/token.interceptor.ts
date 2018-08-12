import {
    HttpResponse,
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


const appKey: string = "kid_rJuhpTmSQ";
const appSecret: string = "416f44c08dc14aed88d60ff532356490";


@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    //we receive this method from the HttpInterceptor interface which sets the headers for us.
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        if (req.url.endsWith('login') || req.url.endsWith(appKey)) {

            req = req.clone({
                setHeaders: {
                    "Authorization": `Basic ${btoa(`${appKey}:${appSecret}`)}`,
                    "Content-Type": 'application/json'
                }
            })

            
        }
        else {

            req = req.clone({
                setHeaders: {
                    "Authorization" : `Kinvey ${localStorage.getItem("authtoken")}`,
                    "Content-Type" : "application/json"
                }
            })            
        }

        //we call the next handle
        return next.handle(req);
    }

    constructor() { }
}

//we have to import this in app.module.ts in providers but LIKE THIS:
/*
{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi : true
}
*/