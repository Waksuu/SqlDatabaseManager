import { NgModule } from '@angular/core';

import { DatabaseComponent } from './database.component';
import { DatabaseServerExplorerModule } from './database-server-explorer/database-server-explorer.module';


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
