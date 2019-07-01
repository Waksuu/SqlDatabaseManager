import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { apiUrl } from 'src/app/shared-kernel/api.helper';
import { AuthenticationService } from 'src/app/authentication/authentication.service';
import { DatabaseExplorer } from './database-explorer/database-explorer.model';
import { databaseManagerEndpoint as endpoint } from 'src/app/shared-kernel/api-endpoint-constants.helper';
import { TableExplorer } from './database-explorer/table-explorer/table-explorer.model';

@Injectable({
  providedIn: 'root'
})

export class DatabaseServerExplorerService {

  constructor(private authenticationService: AuthenticationService, private http: HttpClient) { }

  public getDatabases(): Observable<DatabaseExplorer[]> {
    let sessionId: string = this.authenticationService.getSession();
    const httpParams: HttpParams = new HttpParams().append("sessionId", sessionId);

    return this.http.get<DatabaseExplorer[]>(apiUrl(endpoint.DatabaseController), { params: httpParams });
  }

  public getTables(databaseName: string): Observable<TableExplorer[]> {
    let sessionId: string = this.authenticationService.getSession();
    const httpParams: HttpParams = new HttpParams().append("sessionId", sessionId).append("databaseName", databaseName);

    return this.http.get<TableExplorer[]>(apiUrl(endpoint.DatabaseController, endpoint.Tables), { params: httpParams });
  }
}
