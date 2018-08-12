
import {
    HttpResponse,
    HttpRequest,
    HttpHandler,
    HttpInterceptor,
    HttpEventType,
    HttpEvent,
    HttpErrorResponse
} from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators'; //it changes the observable before we subscribe to it
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
    

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    
    constructor(private toastr : ToastrService){} 
        
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        //To catch errors we use 'catchError' from rxjs/operators   it's very simple
        return next.handle(req)
        .pipe(catchError((err : HttpErrorResponse) => {



            //we use the toaster service to see the error
            //npm install ngx-toastr --save    
            //import it into app.module.ts and pass it true the constructor to use it.

            switch(err.status){
                case 401 :
                    //this is when the user is not authorized, meanint invalid username ot password                
                    this.toastr.error(err.error.message, "Warning!");
                    break;
                case 404 :
                    //not found
                    this.toastr.error(err.error.message, "Warning!");
                    break;
                case 400 :

                //bad request, meaning the request is not correctly formed
                    const message = Object.keys(err.error.errors)
                    .map(e => err.error.errors[e])
                    .join('\n')

                    this.toastr.error(message, "Warning!");

                    break;
                default:
                    break;
                     
            }

            return throwError(err);
        }));


    }

}