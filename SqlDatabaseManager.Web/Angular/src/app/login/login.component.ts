import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../authentication/authentication.service';
import { Login } from './login.model';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: Login = new Login();

  constructor(private loginService: LoginService, private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit() {
  }

  async onSubmit() {
    let sessionId: string = await this.loginService.login(this.login).toPromise();

    this.authenticationService.saveSession(sessionId);

    this.router.navigate(["/database"]);
  }

}
