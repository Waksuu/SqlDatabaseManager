import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { DatabaseExplorer } from './database-explorer.dto';
import { DatabaseServerExplorerService } from '../database-server-explorer.service';

@Component({
  selector: 'app-database-explorer',
  templateUrl: './database-explorer.component.html',
  styleUrls: ['./database-explorer.component.css']
})
export class DatabaseExplorerComponent implements OnInit {
  //TODO: Hide implementation details from html
  public databasesTablesRetrieved: Map<string, boolean>;
  public databases$: Observable<DatabaseExplorer[]>;

  constructor(private readonly databaseServerExplorerService: DatabaseServerExplorerService) { }

  public ngOnInit(): void {
    this.databasesTablesRetrieved = new Map<string, boolean>();
    this.databases$ = this.databaseServerExplorerService.getDatabases();
  }
}
