import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivationEnd, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter, throttleTime } from 'rxjs/operators';
import { UserService } from '../../user/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnDestroy {

  hideNavigation = false;
  subscription: Subscription;

  get isLogged(): boolean {
    return this.userService.isLogged;
  }

  constructor(public userService: UserService, router: Router) {
    this.subscription = router.events.pipe(filter(e => e instanceof ActivationEnd), throttleTime(0)).subscribe((e: any) => {
      this.hideNavigation = !!e.snapshot.data?.noNavigation;
    });
  }

  logoutHandler(): void {
    this.userService.logout();
  }

  ngOnDestroy(): void {
    // In this case this is not needed because this is a main component
    // so it lill be destroyed when the application is removed (when we leave the app)
    // but it's good practice to always unsubscribe to subscriptions
    this.subscription.unsubscribe();
  }
}
