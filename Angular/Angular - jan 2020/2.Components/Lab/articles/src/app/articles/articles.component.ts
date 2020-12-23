import { Component, OnInit } from '@angular/core';
import {Data} from '../data';
 
@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {

  articles = new Data().getData();

  constructor() { }

  ngOnInit(): void {
  }

}
