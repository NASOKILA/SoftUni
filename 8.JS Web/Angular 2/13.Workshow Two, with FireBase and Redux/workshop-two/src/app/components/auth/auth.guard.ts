import { Injectable } from '@angular/core';
import { 
  CanActivate, 
  ActivatedRouteSnapshot, 
  RouterStateSnapshot, 
  Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

constructor(private authService : AuthService, private router : Router){}

  canActivate(
    next: ActivatedRouteSnapshot,  //mwe can access the url from here
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    
    if(this.authService.isAuthenticated()){
      return true;
    }

    this.router.navigate(['/auth/signin']);
    return false;
  }
}
