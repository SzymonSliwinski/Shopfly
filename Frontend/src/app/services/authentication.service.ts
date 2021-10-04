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
        const storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };
        if (storage && new Date(storage.token.expirationDate).getTime() > new Date().getTime())
            return true;
        if (storage && new Date(storage.token.expirationDate).getTime() < new Date().getTime())
            localStorage.removeItem(environment._shopStorageKey);

        return this.router.navigate(['panel/sign-in']);
    }
}