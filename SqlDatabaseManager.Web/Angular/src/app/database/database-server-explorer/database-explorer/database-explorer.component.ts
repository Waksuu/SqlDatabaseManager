import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { DatabaseExplorer } from './database-explorer.model';
import { DatabaseServerExplorerService } from '../database-server-explorer.service';

@Component({
  selector: 'app-database-explorer',
  templateUrl: './database-explorer.component.html',
  styleUrls: ['./database-explorer.component.css']
})

export class DatabaseExplorerComponent implements OnInit {
  databasesTablesRetrieved: Map<string, boolean>;
  databases$: Observable<DatabaseExplorer[]>;

  constructor(private databaseServerExoplorerService: DatabaseServerExplorerService) { }

  ngOnInit() {
    this.databasesTablesRetrieved = new Map<string, boolean>();
    this.databases$ = this.databaseServerExoplorerService.getDatabases();
  }
}
