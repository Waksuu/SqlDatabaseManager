import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AuthenticationService } from '../authentication/authentication.service';
import { ConnectionService } from './connection.service';
import { LoginComponent } from './login/login.component';

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
    ConnectionService,
  ]
})

export class ConnectionModule { }
