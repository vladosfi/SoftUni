import { Component, DoCheck } from '@angular/core';
import { UserService } from '../user/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements DoCheck {

  isLogged = false;

  constructor(private userService: UserService) { }

  ngDoCheck(): void {
    this.isLogged = this.userService.isLogged;
  }

}
