import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateChild, Router, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from "rxjs";
import { map, tap } from "rxjs/operators";
import { IUser } from "../../shared/interfaces";
import { AuthService } from "../auth.service";

@Injectable()
export class AuthGuard implements CanActivateChild {

    constructor(
        private authService: AuthService,
        private router: Router
    ) { }
    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        let stream$: Observable<IUser | null>

        if (this.authService.currentUser === undefined) {
            stream$ = this.authService.authenticate();
        } else {
            stream$ = of(this.authService.currentUser);
        }

        return stream$.pipe(
            map((user) => {
                const isLoggedFromData = childRoute.data.isLogged;
                return typeof isLoggedFromData !== 'boolean' || isLoggedFromData === !!user;
            }),
            tap((canContinue) => {
                if (canContinue) {
                    return;
                }

                const url = this.router.url;
                this.router.navigateByUrl(url);
            })
        );
    }
}