import { Component, OnInit, Input } from '@angular/core';

import { DatabaseService } from '../database/database.service';
import { TableDTO } from '../database/tableDTO.model';

@Component({
  selector: 'app-table-explorer-nav',
  templateUrl: './table-explorer-nav.component.html',
  styleUrls: ['./table-explorer-nav.component.css']
})

export class TableExplorerNavComponent implements OnInit {
  public tables: TableDTO[];

  @Input() databaseName: string;

  constructor(private databaseService: DatabaseService) { }

  ngOnInit() {
    this.databaseService.getTables(this.databaseName).subscribe(tables => this.tables = tables);
  }
}
