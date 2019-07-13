import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { DatabaseExplorer } from './database-explorer/database-explorer.dto';
import { DatabaseServerExplorerService } from './database-server-explorer.service';
import { TableExplorer } from './database-explorer/table-explorer/table-explorer.dto';

@Injectable({
  providedIn: 'root'
})
export class DatabaseServerExplorerServiceMock extends DatabaseServerExplorerService {
  private databases: DatabaseExplorer[] = [
    { name: "Customer" },
    { name: "Member" },
    { name: "Product" },
    { name: "Order" },
    { name: "Shipping Details" },
  ];

  private tables: TableExplorer[] = [
    { name: "Mock Table 1" },
    { name: "Mock Table 2" },
    { name: "Mock Table 3" },
    { name: "Mock Table 4" },
    { name: "Mock Table 5" },
  ];

  public getDatabases(): Observable<DatabaseExplorer[]> {
    return of(this.databases);
  }

  public getTables(databaseName: string): Observable<TableExplorer[]> {
    return of(this.tables);
  }
}
