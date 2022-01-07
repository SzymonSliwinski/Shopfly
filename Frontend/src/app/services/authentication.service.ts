import { Injectable, OnInit } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from "@angular/router";
import { environment } from "src/environments/environment";
import { Profile } from "../models/shop-panel-models/profile.model";
import { PanelAuthenticationService } from "./shop-panel-services/panel-authentication.service";
import { ProfileService } from "./shop-panel-services/profile.service";
@Injectable()
export class AuthenticationService implements CanActivate {
    private _userProfiles: Profile[] = [];
    constructor(
        private router: Router,
        private readonly panelAuthService: PanelAuthenticationService,
        private readonly _profileService: ProfileService
    ) {
        this.setUserProfiles();
    }

    private async setUserProfiles() {
        const storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };
        this._userProfiles = await this._profileService.getProfilesForEmployee(storage.token.userId);
    }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot)
        : boolean | Promise<boolean> {
        const storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };
        if (storage && new Date(storage.token.expirationDate).getTime() > new Date().getTime()) {
            if (storage.token.userId === 1)
                return true;
            if (state.url === '/panel/dashboard')
                return true;
            return this.isProfileMatchWithPage(state.url)
        }
        if (storage && new Date(storage.token.expirationDate).getTime() < new Date().getTime())
            this.panelAuthService.logout();


        return this.router.navigate(['panel/sign-in']);
    }

    private isProfileMatchWithPage(page: string): boolean {
        let orders = false;
        let products = false;
        let customers = false;
        let charts = false;
        let settings = false;
        let api = false;
        let employee = false;
        let importPage = false;

        this._userProfiles.forEach((profile: Profile) => {
            profile.hasAccessToSettings ? settings = true : '';
            profile.hasAccessToApi ? api = true : '';
            profile.hasAccessToCharts ? charts = true : '';
            profile.hasAccessToEmployees ? employee = true : '';
            profile.hasAccessToCustomers ? customers = true : '';
            profile.hasAccessToImports ? importPage = true : '';
            profile.hasAccessToProducts ? products = true : '';
            profile.hasAccessToOrders ? orders = true : '';
        });

        if (page === '/panel/orders' && orders)
            return true;
        if (page === '/panel/products' && products)
            return true;
        if (page === '/panel/customers' && customers)
            return true;
        if (page === '/panel/charts' && charts)
            return true;
        if (page === '/panel/shop-settings' && settings)
            return true;
        if (page === '/panel/api' && api)
            return true;
        if (page === '/panel/employees' && employee)
            return true;
        if (page === '/panel/import' && importPage)
            return true;

        return false;
    }
}