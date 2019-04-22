import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { apiUrl } from '../shared-kernel/api.helper';
import { Login } from './login/login.model';

@Injectable({
  providedIn: "root"
})

export class ConnectionService {
  constructor(protected readonly http: HttpClient) { }

  login(login: Login): Observable<string> {
    return this.http.post<string>(apiUrl("Database","Login"), login);
  }
}
