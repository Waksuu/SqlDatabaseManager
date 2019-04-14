import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-database-explorer-nav',
  templateUrl: './database-explorer-nav.component.html',
  styleUrls: ['./database-explorer-nav.component.css']
})

export class DatabaseExplorerNavComponent implements OnInit {
  public databases: DatabaseDTO[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DatabaseDTO[]>(baseUrl + 'api/Database/GetDatabases').subscribe(result => {
      this.databases = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }
}

interface DatabaseDTO {
  name: string;
}
