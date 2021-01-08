import { Component, HostBinding, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  @HostBinding('class.test1') hasClassTest = true;

  constructor() { }

  ngOnInit(): void {
  }

}
