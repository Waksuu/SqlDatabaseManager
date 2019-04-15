import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-table-explorer-nav',
  templateUrl: './table-explorer-nav.component.html',
  styleUrls: ['./table-explorer-nav.component.css']
})
export class TableExplorerNavComponent implements OnInit {

  @Input() databaseName: string;

  constructor() { }

  ngOnInit() {
  }

}
