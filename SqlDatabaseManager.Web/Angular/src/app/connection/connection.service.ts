import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from "rxjs/operators";

import { apiUrl } from '../shared-kernel/api.helper';
import { AuthenticationService } from '../authentication/authentication.service';
import { databaseManagerEndpoint as endpoint } from '../shared-kernel/api-endpoint-constants.helper';
import { Login } from './login/login.model';

@Injectable()
export class ConnectionService {
  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  login(login: Login): Observable<string> {
    return this.http.post<string>(apiUrl(endpoint.DatabaseController, endpoint.Login), login).pipe(
      tap(sessionId => this.authenticationService.saveSession(sessionId))
    );
  }

  logout(): Observable<any> {
    const sessionId: string = this.authenticationService.getSession();
    const httpParams: HttpParams = new HttpParams().append("sessionId", sessionId);

    return this.http.delete(apiUrl(endpoint.DatabaseController, endpoint.Logout), { params: httpParams }).pipe(
      tap(() => this.authenticationService.deleteSession())
    );
  }
}
