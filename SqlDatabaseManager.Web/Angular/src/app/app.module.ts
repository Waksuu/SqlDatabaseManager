import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatExpansionModule } from '@angular/material/expansion';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DatabaseExplorerNavComponent } from './database/database-explorer-nav/database-explorer-nav.component';
import { SecurityModule } from './security/security.module';
import { TableExplorerNavComponent } from './database/table-explorer-nav/table-explorer-nav.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    DatabaseExplorerNavComponent,
    TableExplorerNavComponent,
    LoginComponent,
  ],
  imports: [
    AppRoutingModule,
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
