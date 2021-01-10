import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../../../form-styles.css', './login.component.css']
})

export class LoginComponent implements OnInit {
  isLoading = false;
  errorMessage: string = '';

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }


  submitFormHandler(formValue: { email: string, password: string }): void {
    this.errorMessage = '';

    this.isLoading = true;
    this.userService.login(formValue).subscribe({
      next: (data) => {
        this.isLoading = false;
        this.router.navigate(['/']);
      },
      error: (err) => {
        this.errorMessage = 'Error!';
        this.isLoading = false;
      }
    });
  }
}
