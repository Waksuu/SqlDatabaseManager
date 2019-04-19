import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { LoginComponent } from './login.component';
import { LoginService } from './login.service';

@NgModule({
  declarations: [
    LoginComponent,
  ],


  imports: [
    BrowserModule,
    CommonModule,
  ],

  exports: [
    LoginComponent,
  ],

  providers: [
    LoginService
  ]
})

export class LoginModule { }
