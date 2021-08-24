import { Injectable } from "@angular/core";
import {  CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";

@Injectable()
export class AuthenticationService implements CanActivate{
    canActivate(next: ActivatedRouteSnapshot, state:RouterStateSnapshot)
    : boolean{
        // todo check if token expires
        // if expired go with request to remove it and set acces danied goto login page
        return true;

        //else go to where u want to go
    }
}