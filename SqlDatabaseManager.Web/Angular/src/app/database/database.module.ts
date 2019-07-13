import { NgModule } from '@angular/core';

import { ConnectionModule } from '../connection/connection.module';
import { DatabaseComponent } from './database.component';
import { DatabaseServerExplorerModule } from './database-server-explorer/database-server-explorer.module';


@NgModule({
  declarations: [
    DatabaseComponent
  ],

  imports: [
    DatabaseServerExplorerModule,
    ConnectionModule
  ],

  exports: [
    DatabaseComponent
  ]
})
export class DatabaseModule { }
