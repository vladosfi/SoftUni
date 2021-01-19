import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ITheme } from '../shared/interfaces/theme';
import { Observable } from 'rxjs';
import { IPost } from '../shared/interfaces';

@Injectable()
export class ThemeService {

  constructor(private http: HttpClient) { }

  loadThemeList(): Observable<ITheme[]> {
    return this.http.get<ITheme[]>(`/themes`, { withCredentials: true });
  }

  loadTheme(id: string): Observable<ITheme<IPost>> {
    return this.http.get<ITheme<IPost>>(`/themes/${id}`, { withCredentials: true });
  }

  saveTheme(data: any): Observable<ITheme<any>> {
    return this.http.post<ITheme<any>>(`/themes`, data, { withCredentials: true });
  }
}
