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
  databases$: Observable<DatabaseExplorer[]>;

  private databaseTablesRetrieved: Map<string, boolean>;

  constructor(private readonly databaseServerExplorerService: DatabaseServerExplorerService) { }

  ngOnInit(): void {
    this.databaseTablesRetrieved = new Map<string, boolean>();
    this.databases$ = this.databaseServerExplorerService.getDatabases();
  }

  initializeTablesRetrieved(databaseName: string): void {
    this.databaseTablesRetrieved.set(databaseName, true);
  }

  databaseTablesRetrievedInitialized(databaseName: string): boolean {
    return this.databaseTablesRetrieved.get(databaseName);
  }
}
