import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Test App Title';

  visible = false;

  users = [{
      name: 'Test 1',
      age: 10
    },
    {
      name: 'Test 2',
      age: 11
    },
    {
      name: 'Test 3',
      age: 12
    }
  ]

  toggleVisible(){
    this.visible = !this.visible;
  }
}
