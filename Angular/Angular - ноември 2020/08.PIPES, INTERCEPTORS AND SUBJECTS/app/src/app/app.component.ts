import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { shareReplay } from 'rxjs/operators';
import { PostService } from './post.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  posts$: Observable<any[]>;

  constructor(private postsService: PostService) {

  }

  ngOnInit(): void {
    this.posts$ = this.postsService.loadPosts();
    shareReplay(1);    
  }
}
