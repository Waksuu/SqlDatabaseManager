import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';

import { apiUrl } from 'src/app/shared-kernel/api.helper';
import { Database } from './Database.model';
import { Table } from './table.model';

@Injectable({
  providedIn: 'root'
})

export class DatabaseService {

  constructor(private http: HttpClient) { }

  public getDatabases(): Observable<Database[]> {
    return this.http.get<Database[]>(apiUrl('Database', 'GetDatabases'));
  }

  public getTables(databaseName: string): Observable<Table[]> {
    const httpParams: HttpParams = new HttpParams().append("databaseName", databaseName);

    return this.http.get<Table[]>(apiUrl('Database', 'GetTables'), { params: httpParams });
  }
}
