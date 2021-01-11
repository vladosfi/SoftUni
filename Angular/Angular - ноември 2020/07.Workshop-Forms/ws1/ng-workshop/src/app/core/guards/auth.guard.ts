import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable, of } from "rxjs";
import { map, tap } from "rxjs/operators";
import { IUser } from "src/app/shared/interfaces";
import { UserService } from "src/app/user/user.service";

@Injectable()
export class AuthGuard implements CanActivateChild {

    constructor(
        private userService: UserService,
        private router: Router
    ) { }
    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        let stream$: Observable<IUser | null>

        if (this.userService.currentUser === undefined) {
            stream$ = this.userService.getCurrentUserProfile();
        } else {
            stream$ = of(this.userService.currentUser);
        }

        return stream$.pipe(
            tap((user: IUser | null) => {
                const isLoggedFromData = childRoute.data.isLogged;

                if (typeof isLoggedFromData === 'boolean' && isLoggedFromData === !!user) {
                    return;
                }

                const url = this.router.url;
                this.router.navigateByUrl(url);
            }),
            map((user: IUser | null) => !!user)
        );
    }
}