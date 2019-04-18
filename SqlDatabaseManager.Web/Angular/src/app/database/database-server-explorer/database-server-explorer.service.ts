import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';

import { apiUrl } from 'src/app/shared-kernel/api.helper';
import { DatabaseExplorer } from './database-explorer/database-explorer.model';
import { TableExplorer } from './database-explorer/table-explorer/table-explorer.model';

@Injectable({
  providedIn: 'root'
})

export class DatabaseServerExplorerService {

  constructor(private http: HttpClient) { }

  public getDatabases(): Observable<DatabaseExplorer[]> {
    return this.http.get<DatabaseExplorer[]>(apiUrl('Database', 'GetDatabases'));
  }

  public getTables(databaseName: string): Observable<TableExplorer[]> {
    const httpParams: HttpParams = new HttpParams().append("databaseName", databaseName);

    return this.http.get<TableExplorer[]>(apiUrl('Database', 'GetTables'), { params: httpParams });
  }
}
