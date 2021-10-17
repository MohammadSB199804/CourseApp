import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';

// this is a root module 

@NgModule({ // angular module declares the components that are avaliable inside our application
  declarations: [
    AppComponent
  ],
  imports: [ // for import angular modules into other modules and make use of them in our app  
    BrowserModule, // for creating single page app .
    AppRoutingModule ,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
