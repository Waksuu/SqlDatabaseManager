import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';

import { DatabaseServerExplorerService } from '../../database-server-explorer.service';
import { TableExplorer } from './table-explorer.dto';


@Component({
  selector: 'app-table-explorer',
  templateUrl: './table-explorer.component.html',
  styleUrls: ['./table-explorer.component.css']
})
export class TableExplorerComponent implements OnInit {
  public tables$: Observable<TableExplorer[]>;

  @Input() databaseName: string;

  constructor(private readonly databaseServerExoplorerService: DatabaseServerExplorerService) { }

  public ngOnInit() {
    this.tables$ = this.databaseServerExoplorerService.getTables(this.databaseName);
  }
}
