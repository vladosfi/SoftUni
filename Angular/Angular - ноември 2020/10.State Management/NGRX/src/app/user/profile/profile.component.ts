import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/auth.service';
import { IUser } from 'src/app/shared/interfaces';
import { UserService } from '../user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  inEditMode = false;
  currentUser$ = this.authService.currentUser$;

   constructor(
    private authService: AuthService,
    private userService: UserService
    ) { }

  ngOnInit(): void {
  }

  toggleEditMode(): void {
    this.inEditMode = !this.inEditMode;
  }

  submitHandler(data: IUser): void {
    this.userService.updateProfile(data).subscribe({
      next: () => {
        this.inEditMode = false;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
