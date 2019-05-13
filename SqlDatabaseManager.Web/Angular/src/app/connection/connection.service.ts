import { Injectable, OnDestroy } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';

import { apiUrl } from '../shared-kernel/api.helper';
import { AuthenticationService } from '../authentication/authentication.service';
import { Login } from './login/login.model';

@Injectable()
export class ConnectionService implements OnDestroy {
  private subscription: Subscription = new Subscription();

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  login(login: Login): void {
    let sessionId: string;

    let loginRequest: Observable<string> = this.http.post<string>(apiUrl("Database", "Login"), login);
    this.subscription.add(loginRequest.subscribe(x => sessionId = x));

    this.authenticationService.saveSession(sessionId);
  }

  logout(): void {
    let sessionId: string = this.authenticationService.getSession();
    const httpParams: HttpParams = new HttpParams().append("sessionId", sessionId);

    let logoutRequest: Observable<any> = this.http.delete(apiUrl("Database", "Logout"), { params: httpParams });
    this.subscription.add(logoutRequest.subscribe());

    this.authenticationService.deleteSession();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
