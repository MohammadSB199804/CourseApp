import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';

// this is a root module 

@NgModule({ // angular module declares the components that are avaliable inside our application
  declarations: [
    AppComponent,
    NavComponent,
    
  ],
  imports: [ // for import angular modules into other modules and make use of them in our app  
    BrowserModule, // for creating single page app .
    AppRoutingModule ,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
