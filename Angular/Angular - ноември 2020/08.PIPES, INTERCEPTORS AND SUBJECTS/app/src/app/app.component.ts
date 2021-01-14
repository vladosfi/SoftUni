import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
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
  subjectTest$: Subject<any> = new Subject();

  constructor(private postsService: PostService) {
    this.subjectTest$.subscribe({
      next: console.log,
      error: console.log      
    });

    setTimeout(() => {
      this.subjectTest$.next(100);
       this.subjectTest$.error(new Error('! -------- Subject Error -------- ! :)'));
       this.subjectTest$.complete();
    }, 1000);
  }


  ngOnInit(): void {
    this.posts$ = this.postsService.loadPosts();
    shareReplay(1);
  }
}
