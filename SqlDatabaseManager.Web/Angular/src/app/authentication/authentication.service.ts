import { Injectable } from '@angular/core';


@Injectable({
  providedIn: "root"
})

export class AuthenticationService {
  constructor() { }

  saveSession(sessionId: string): void {
    localStorage.setItem("sessionId", sessionId);
  }

  getSession(): string {
    return localStorage.getItem("sessionId");
  }
}
