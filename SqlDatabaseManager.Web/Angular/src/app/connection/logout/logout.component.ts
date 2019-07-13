import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';

import { ConnectionService } from '../connection.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnDestroy {
  public logoutRequest$: Subscription;

  constructor(private readonly connectionService: ConnectionService, private readonly router: Router) { }

  public onLogoutClick(): void {
    this.logoutRequest$ = this.connectionService.logout().pipe(
      tap(() => this.router.navigate(["/login"]))
    ).subscribe();
  }

  public ngOnDestroy(): void {
    this.logoutRequest$.unsubscribe();
  }
}
