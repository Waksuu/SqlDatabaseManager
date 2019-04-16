import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';

import { DatabaseDTO } from './DatabaseDTO.model';

@Injectable({
  providedIn: 'root'
})

export class DatabaseService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getDatabases(): Observable<DatabaseDTO[]> {
    return this.http.get<DatabaseDTO[]>(this.baseUrl + 'api/Database/GetDatabases');
  }
}
