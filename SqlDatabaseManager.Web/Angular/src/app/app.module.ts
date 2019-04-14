import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatExpansionModule } from '@angular/material/expansion';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { DatabaseExplorerNavComponent } from './database-explorer-nav/database-explorer-nav.component';
import { TableExplorerNavComponent } from './table-explorer-nav/table-explorer-nav.component';

@NgModule({
  declarations: [
    AppComponent,
    DatabaseExplorerNavComponent,
    TableExplorerNavComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatExpansionModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
