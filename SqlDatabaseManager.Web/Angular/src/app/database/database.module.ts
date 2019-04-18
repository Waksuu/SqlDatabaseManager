import { NgModule } from '@angular/core';

import { DatabaseServerExplorerModule } from './database-server-explorer/database-server-explorer.module';
import { DatabaseServerExplorerComponent } from './database-server-explorer/database-server-explorer.component';
import { DatabaseComponent } from './database.component';


@NgModule({
  declarations: [
    DatabaseComponent,
  ],

  imports: [
    DatabaseServerExplorerModule
  ],

  exports: [
    DatabaseComponent
  ]
})

export class DatabaseModule { }
