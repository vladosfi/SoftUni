import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ITheme} from '../shared/interfaces/theme';
import { Observable } from 'rxjs';
import {environment} from '../../environments/environment';
import { IPost } from '../shared/interfaces';
const apiUrl = environment.apiUrl;

@Injectable()
export class ThemeService {

  constructor(private http: HttpClient) { }

  loadThemeList(): Observable<ITheme[]>{
    return this.http.get<ITheme[]>(`${apiUrl}/themes`);
  }

  loadTheme(id: string): Observable<ITheme<IPost>>{
    return this.http.get<ITheme<IPost>>(`${apiUrl}/themes/${id}`);
  }
}
