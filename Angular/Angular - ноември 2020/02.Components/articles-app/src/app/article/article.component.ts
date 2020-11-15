import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Article } from '../models/article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})

export class ArticleComponent implements OnInit {
  private symbols: number = 250;
  @Input() article: Article;
  @Input() articleDesc: string;
  @Output() delete: EventEmitter<any> = new EventEmitter();

  descToShow: string;
  articleDescLen: number;
  showReadMoreBtn: boolean = true;
  showHideBtn: boolean = false;
  imageIsShown: boolean = false;
  imageButtonTitle: string = "Show Image";

  constructor() {
    this.articleDescLen = 0;
    this.descToShow = "";
  }

  readMore() {
    if (this.articleDescLen < this.article.description.length) {
      this.articleDescLen += this.symbols;
      this.descToShow = this.article.description.slice(0, this.articleDescLen);
    } 
    if(this.articleDescLen >= this.article.description.length){
      this.showReadMoreBtn = false;
      this.showHideBtn = true;
    }
  }
  toggleImage() {
    this.imageIsShown =!this.imageIsShown;
    this.imageButtonTitle = this.imageButtonTitle !== "Show Image" ? "Show Image" : "Hide Image";
  }

  hideDesc() {
    this.showHideBtn = false;
    this.showReadMoreBtn = true;
    this.articleDescLen = 0;
    this.descToShow = "";
  }

  deleteHandler(){
    console.log('Passing Event from child to parent!');
    this.delete.emit(this.article);
  }

  ngOnInit(): void {
  }

}
