import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  loadPosts() {
    return this.http.get<any[]>('https://jsonplaceholder.typicode.com/posts');
  }
}
