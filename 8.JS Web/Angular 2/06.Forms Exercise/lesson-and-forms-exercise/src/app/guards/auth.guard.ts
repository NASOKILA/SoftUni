import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../../authentication/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private authService : AuthService, private router : Router){

  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
   
     //If we return true we pass thru the guard otherwise we cannot and we will redirect.

      //we use the function from the service to see if we can activate and pass true this guard
      if(this.authService.checkIfLoggedIn()){
        return true;
      }

      //if not we redirect and we return true
      this.router.navigate(['/login']);
      return false;
    }
}