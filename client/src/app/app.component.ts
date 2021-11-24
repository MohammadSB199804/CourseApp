import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { user } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'API';
  users: any; //TypeSaftey

  constructor(private http:HttpClient , private accountService : AccountService){ // Angular comes with lifecycle events , the lifecycle event that takes place after the constructor known as initilization 

  }
  ngOnInit() {
    this.getUsers();
    this.setCurrentUser();
  }

  setCurrentUser(){
    const user:user=JSON.parse(localStorage.getItem('user')!);
    this.accountService.setCurrentUser(user);
  }

  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe(response => {   // we have an ok param. and error param. as functions in subscriber method.
        this.users = response;
    }, error => {
      console.log(error);
    });
  }
}
   