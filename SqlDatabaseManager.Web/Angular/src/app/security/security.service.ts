import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Login } from '../login/login.model';

@Injectable({ providedIn: "root" })
export class SecurityService {
  constructor(protected readonly http: HttpClient) { }

  login(loginDto: Login): Observable<any> {
    return this.http.post("/api/login", loginDto);
  }
}
