import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from "@angular/router";
import { environment } from "src/environments/environment";

@Injectable()
export class AuthenticationService implements CanActivate {
    constructor(
        private router: Router,
    ) { }
    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot)
        : boolean | Promise<boolean> {
        if (localStorage.getItem(environment._panelStorageKey) !== null)
            return true;

        return this.router.navigate(['panel/sign-in']);
    }
}