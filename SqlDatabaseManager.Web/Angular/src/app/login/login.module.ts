import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
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
    FormsModule,
  ],

  exports: [
    LoginComponent,
  ],

  providers: [
    LoginService
  ]
})

export class LoginModule { }
