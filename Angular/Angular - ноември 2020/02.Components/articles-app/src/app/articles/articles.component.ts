import { Component, OnInit } from '@angular/core';
import { ArticleData } from '../data/data';
import { Article } from '../models/article.model';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  articles: Article[];

  constructor() { }

  deleteArticleHandler(article){
    console.log('Delete Article!');
    this.articles = this.articles.filter(a => a !== article);
  }

  ngOnInit(): void {
    this.articles = new ArticleData().getData();
  }

}
