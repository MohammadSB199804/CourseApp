import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { user } from '../_models/user';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';

  private currentUserSource = new ReplaySubject<user>(1); //new observer "Buffer"
  currentUser$ = this.currentUserSource.asObservable(); // new Observable

  constructor(private http:HttpClient) {

   }

   login(model:any){
     return this.http.post(this.baseUrl + 'Account/login',model).pipe(
       map((response : any)=>{
        const user = response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
       })
     );
   }
   setCurrentUser(user:user){
    this.currentUserSource.next(user);
   }

   logOut(){
    localStorage.removeItem('user');
    this.currentUserSource.next();
  }
}

