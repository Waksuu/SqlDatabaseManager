import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ConnectionService } from '../connection.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private connectionService: ConnectionService, private router: Router) { }

  ngOnInit() {
  }

  onLogoutClick() {
    this.connectionService.logout();
    this.router.navigate(["/login"]);
  }
}
