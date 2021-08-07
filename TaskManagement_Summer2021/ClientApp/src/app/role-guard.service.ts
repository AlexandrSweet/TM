import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleGuardService implements CanActivate  {

  constructor(private router: Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const role = localStorage.getItem('loginUserRole');
    if (role && role === 'Administrator') {
      return true;
    }
    if (role && role === 'Customer') {
      return true;
    }
    else {
      this.router.navigate(['/dashboard']);
        return false;
    }
    }
}
