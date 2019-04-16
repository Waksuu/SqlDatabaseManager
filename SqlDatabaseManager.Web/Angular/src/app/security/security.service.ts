import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface LoginDto {
  username: string;
  password: string;
}

@Injectable({ providedIn: "root" })
export class SecurityService {
  constructor(protected readonly http: HttpClient) { }

  login(loginDto: LoginDto): Observable<any> {
    return this.http.post("/api/login", loginDto);
  }
}
