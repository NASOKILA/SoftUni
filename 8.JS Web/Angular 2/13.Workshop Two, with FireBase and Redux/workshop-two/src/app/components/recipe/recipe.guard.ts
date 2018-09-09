import { Injectable } from '@angular/core';
import { 
  CanActivate, 
  ActivatedRouteSnapshot, 
  RouterStateSnapshot, 
  Router } from '@angular/router';

import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeGuard implements CanActivate {

constructor(private authService : AuthService, private router : Router){}

  canActivate(
    next: ActivatedRouteSnapshot,  //mwe can access the url from here
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    
    if(this.authService.isAuthenticated() === false){
      return true;
    }

    this.router.navigate(['/recipes/start']);
    return false;
  }
}
