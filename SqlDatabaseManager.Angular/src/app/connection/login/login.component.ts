import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';

import { ConnectionService } from '../connection.service';
import { Login } from './login.dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  public login: Login;
  public loginRequest$: Subscription;

  constructor(private readonly connectionService: ConnectionService, private readonly router: Router) { }

  public ngOnInit(): void {
    this.login = {} as Login;
  }

  public onSubmit(): void {
    this.loginRequest$ = this.connectionService.login(this.login).pipe(
      tap(() => this.router.navigate(["/database"]))
    ).subscribe();
  }

  public ngOnDestroy(): void {
    this.loginRequest$.unsubscribe();
  }
}
