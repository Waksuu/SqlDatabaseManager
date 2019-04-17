import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';

import { DatabaseService } from '../shared/database.service';
import { TableDTO } from '../shared/tableDTO.model';


@Component({
  selector: 'app-table-explorer-nav',
  templateUrl: './table-explorer-nav.component.html',
  styleUrls: ['./table-explorer-nav.component.css']
})

export class TableExplorerNavComponent implements OnInit {
  public tables$: Observable<TableDTO[]>;

  @Input() databaseName: string;

  constructor(private databaseService: DatabaseService) { }

  ngOnInit() {
    this.tables$ = this.databaseService.getTables(this.databaseName);
  }
}
