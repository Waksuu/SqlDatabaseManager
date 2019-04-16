import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { DatabaseDTO } from '../DatabaseDTO.model';
import { DatabaseService } from '../database.service';

@Component({
  selector: 'app-database-explorer-nav',
  templateUrl: './database-explorer-nav.component.html',
  styleUrls: ['./database-explorer-nav.component.css']
})

export class DatabaseExplorerNavComponent implements OnInit {
  databases$: Observable<DatabaseDTO[]>;

  constructor(private databaseService: DatabaseService) { }

  ngOnInit() {
    this.databases$ = this.databaseService.getDatabases();
  }
}
