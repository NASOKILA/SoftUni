import {
  HttpRequest,
  HttpEvent,
  HttpInterceptor,
  HttpHandler
} from '@angular/common/http';

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler)
    : Observable<HttpEvent<any>> {
    
      let token = localStorage.getItem('authtoken');
      if (token) {
        req = req.clone({
          setHeaders: { 'Authorization': `Bearer ${token}`  }
        })
      }


      return next.handle(req).pipe(tap((event : HttpEvent<any>) => {
        // save token here
      }));
  }
}