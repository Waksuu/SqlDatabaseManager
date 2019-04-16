import { Component, OnInit } from '@angular/core';

import { DatabaseDTO } from '../database/DatabaseDTO.model';
import { DatabaseService } from '../database/database.service';
import { Observable } from 'rxjs';

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
