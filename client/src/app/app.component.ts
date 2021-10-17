import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating App';

  constructor(private http:HttpClient){ // Angular comes with lifecycle events , the lifecycle event that takes place after the constructor known as initilization 

  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
   