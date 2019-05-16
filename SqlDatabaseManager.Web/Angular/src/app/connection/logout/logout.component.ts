import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';

import { ConnectionService } from '../connection.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit, OnDestroy {
  logoutRequest$: Subscription;

  constructor(private connectionService: ConnectionService, private router: Router) { }

  ngOnInit(): void {
  }

  onLogoutClick(): void {
    this.logoutRequest$ = this.connectionService.logout().pipe(
      tap(() => this.router.navigate(["/login"]))
    ).subscribe();
  }

  ngOnDestroy(): void {
    this.logoutRequest$.unsubscribe();
  }
}
