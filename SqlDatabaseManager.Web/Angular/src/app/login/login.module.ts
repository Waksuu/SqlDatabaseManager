import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AuthenticationService } from '../authentication/authentication.service';
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
    AuthenticationService,
    LoginService,
  ]
})

export class LoginModule { }
