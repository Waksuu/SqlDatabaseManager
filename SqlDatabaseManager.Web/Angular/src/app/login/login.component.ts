import { Component, OnInit } from '@angular/core';

import { Login } from './login.model';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: Login = new Login();

  constructor(private loginService: LoginService) { }

  ngOnInit() {
  }

  onSubmit() {
    console.log(this.login);
    this.loginService.login(this.login).subscribe(x => console.log(x));
  }
}
