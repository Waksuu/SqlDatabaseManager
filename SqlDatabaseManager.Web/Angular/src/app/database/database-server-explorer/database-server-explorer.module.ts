import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { MatExpansionModule } from '@angular/material/expansion';
import { NgModule } from '@angular/core';

import { DatabaseExplorerComponent } from './database-explorer/database-explorer.component';
import { DatabaseServerExplorerComponent } from './database-server-explorer.component';
import { DatabaseServerExplorerService } from './database-server-explorer.service';
import { TableExplorerComponent } from './database-explorer/table-explorer/table-explorer.component';


@NgModule({
  declarations: [
    DatabaseServerExplorerComponent,
    DatabaseExplorerComponent,
    TableExplorerComponent,
  ],

  imports: [
    BrowserAnimationsModule,
    HttpClientModule,
    MatExpansionModule,
  ],

  exports: [
    DatabaseServerExplorerComponent,
  ],

  providers: [
    DatabaseServerExplorerService,
  ]
})

export class DatabaseServerExplorerModule { }
