import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { navItems } from '../navigation/navItems';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {    
        
        //reset password forzato
        if(state.url != '/profile/reset-pwd' && this.authService.mustResetPassword())
        {
            this.router.navigate(['/profile/reset-pwd']);
            return false;
        }

        let navItem = navItems.find(x => x.url == state.url);

        if(navItem == null)
            return false;

        return this.authService.checkPermission(navItem.permission);
    }
}