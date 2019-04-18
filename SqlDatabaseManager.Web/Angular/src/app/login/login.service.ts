import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Login } from '../login/login.model';
import { apiUrl } from '../shared-kernel/api.helper';

@Injectable({
  providedIn: "root"
})

export class LoginService {
  constructor(protected readonly http: HttpClient) { }

  login(loginDto: Login): Observable<any> {
    return this.http.post(apiUrl("login"), loginDto);
  }
}
