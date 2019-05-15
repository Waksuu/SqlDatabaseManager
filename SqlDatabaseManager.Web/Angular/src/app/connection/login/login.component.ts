import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from 'src/app/authentication/authentication.service';
import { ConnectionService } from '../connection.service';
import { Login } from './login.model';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  login: Login = new Login();
  login$: Subscription;

  constructor(private connectionService: ConnectionService, private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    this.login$ = this.connectionService.login(this.login).pipe(
        tap(() => this.router.navigate(["/database"]))
      ).subscribe();
  }

  ngOnDestroy(): void {
    this.login$.unsubscribe();
  }
}
