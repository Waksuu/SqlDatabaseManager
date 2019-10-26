import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

//TODO: Break this module down
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
})
export class ConnectionModule { }
