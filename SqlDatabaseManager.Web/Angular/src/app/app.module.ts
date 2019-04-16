import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatExpansionModule } from '@angular/material/expansion';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DatabaseExplorerNavComponent } from './database-explorer-nav/database-explorer-nav.component';
import { TableExplorerNavComponent } from './table-explorer-nav/table-explorer-nav.component';
import { SecurityModule } from './security/security.module';

@NgModule({
  declarations: [
    AppComponent,
    DatabaseExplorerNavComponent,
    TableExplorerNavComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatExpansionModule,

    SecurityModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
