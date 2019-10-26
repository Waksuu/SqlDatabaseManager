import { Injectable } from '@angular/core';

const session: string = "sessionId";

@Injectable({
  providedIn: "root"
})
export class AuthenticationService {
  public saveSession(sessionId: string): void {
    localStorage.setItem(session, sessionId);
  }

  public getSession(): string {
    return localStorage.getItem(session);
  }

  public deleteSession(): void {
    localStorage.removeItem(session)
  }
}
