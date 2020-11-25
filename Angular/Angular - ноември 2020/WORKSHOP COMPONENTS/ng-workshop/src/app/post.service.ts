import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {environment} from '../environments/environment';
import { IPost } from './interfaces/post';
const apiUrl = environment.apiUrl;

@Injectable()
export class PostService {

  constructor(private http: HttpClient) { }

  loadPostList(limit: number): Observable<IPost[]>{
    return this.http.get<IPost[]>(
      `${apiUrl}/posts${limit ? `?limit=${limit}` : ''}`
      );
  }
}
