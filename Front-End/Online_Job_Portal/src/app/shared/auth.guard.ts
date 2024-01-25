import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router,) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const isAuthenticated = this.isAuthenticated();
    if (isAuthenticated) {
      return true;
    } else {
    
      return this.router.createUrlTree(['/login']);
    }
  }
  isAuthenticated():any
  {
    const typeId=0
    if (typeof localStorage !== 'undefined') {
      const typeId=localStorage.getItem("Type:")
      return typeId
    }
    
  }
}
