import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating App';
  users: any; //TypeSaftey

  constructor(private http:HttpClient){ // Angular comes with lifecycle events , the lifecycle event that takes place after the constructor known as initilization 

  }
  ngOnInit() {
    this.getUsers()
  }

  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe(response => {   // we have an ok param. and error param. as functions in subscriber method.
        this.users = response;
    }, error => {
      console.log(error);
    });
  }
}
   