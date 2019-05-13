import { Injectable } from '@angular/core';

const session: string = "sessionId";

@Injectable({
  providedIn: "root"
})

export class AuthenticationService {
  constructor() { }

  saveSession(sessionId: string): void {
    localStorage.setItem(session, sessionId);
  }

  getSession(): string {
    return localStorage.getItem(session);
  }

  deleteSession(): void {
    localStorage.removeItem(session)
  }
}
