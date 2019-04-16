import { Component, Inject, OnInit } from '@angular/core';

import { DatabaseDTO } from '../database/DatabaseDTO.model';
import { DatabaseService } from '../database/database.service';

@Component({
  selector: 'app-database-explorer-nav',
  templateUrl: './database-explorer-nav.component.html',
  styleUrls: ['./database-explorer-nav.component.css']
})

export class DatabaseExplorerNavComponent implements OnInit {
  public databases: DatabaseDTO[];

  constructor(private databaseService: DatabaseService) { }

  ngOnInit() {
    this.databaseService.getDatabases().subscribe(databases => this.databases = databases);
  }
}
