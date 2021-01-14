import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, delay, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../shared/interfaces';
import { AuthService } from '../core/auth.service';



@Injectable({
  providedIn: 'root'
})
export class UserService {


  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) { }

  getCurrentUserProfile(): Observable<any> {
    return this.http.get(`/users/profile`).pipe(
      tap((user: IUser) => this.authService.currentUser = user)
    );
  }

  updateProfile(data: any): Observable<IUser> {
    return this.http.put(`/users/profile`, data).pipe(
      tap((user: IUser) => this.authService.currentUser = user)
    )
  }
}
