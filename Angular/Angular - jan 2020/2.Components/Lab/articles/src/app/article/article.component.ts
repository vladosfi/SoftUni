import { Component, Input, OnInit } from '@angular/core';
import { Article } from '../article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  symbols: number = 250;

  visibleDescriptionLenght: number = 0;
  @Input() article: Article;
  showImage:boolean = true;

  get description() {
    return this.article.description.slice(0, this.visibleDescriptionLenght);
  }

  get hasNoMoreInfo(){
    return this.description.length < this.visibleDescriptionLenght;
  }

  constructor() { }

  hideDescription() {
    this.visibleDescriptionLenght = 0;
  }


  readMore() {
    if (this.description.length < this.visibleDescriptionLenght) { return; }
    this.visibleDescriptionLenght = this.visibleDescriptionLenght + this.symbols;
  }

  toggleImage(){
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
  }

}
