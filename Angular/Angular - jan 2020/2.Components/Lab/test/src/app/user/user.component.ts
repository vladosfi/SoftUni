import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor() { }

  @Input('info') user: { name: string, age: number };
  @Output() delete: EventEmitter<any> = new EventEmitter();

  ngOnInit(): void {
  }

  deleteHandler() {
    this.delete.emit(this.user);
  }
}
