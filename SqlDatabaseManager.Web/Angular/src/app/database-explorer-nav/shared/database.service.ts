import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DatabaseDTO } from './DatabaseDTO.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class DatabaseService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getDatabases(): Observable<DatabaseDTO[]> {
    return this.http.get<DatabaseDTO[]>(this.baseUrl + 'api/Database/GetDatabases');
  }
}
