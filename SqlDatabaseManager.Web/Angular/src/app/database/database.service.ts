import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';

import { apiUrl } from '../shared/api.helper';
import { DatabaseDTO } from './DatabaseDTO.model';
import { TableDTO } from './tableDTO.model';

@Injectable({
  providedIn: 'root'
})

export class DatabaseService {

  constructor(private http: HttpClient) { }

  public getDatabases(): Observable<DatabaseDTO[]> {
    return this.http.get<DatabaseDTO[]>(apiUrl('Database', 'GetDatabases'));
  }

  public getTables(databaseName: string): Observable<TableDTO[]> {
    const httpParams: HttpParams = new HttpParams().append("databaseName", databaseName);

    return this.http.get<TableDTO[]>(apiUrl('Database', 'GetTables'), { params: httpParams });
  }
}
