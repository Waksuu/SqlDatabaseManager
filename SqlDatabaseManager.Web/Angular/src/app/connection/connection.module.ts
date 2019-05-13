import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AuthenticationService } from '../authentication/authentication.service';
import { ConnectionService } from './connection.service';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

@NgModule({
  declarations: [
    LoginComponent,
    LogoutComponent,
  ],

  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
  ],

  exports: [
    LoginComponent,
    LogoutComponent
  ],

  providers: [
    AuthenticationService,
    ConnectionService,
  ]
})

export class ConnectionModule { }
