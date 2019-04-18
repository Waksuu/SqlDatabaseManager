import { NgModule } from '@angular/core';

import { LoginService } from './login.service';
import { LoginComponent } from './login.component';

@NgModule({
  declarations: [
    LoginComponent,
  ],

  exports: [
    LoginComponent,
  ],

  providers: [
    LoginService
  ]
})

export class LoginModule { }
