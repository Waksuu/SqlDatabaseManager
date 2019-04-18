import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatExpansionModule } from '@angular/material/expansion';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './login/login.component';
import { DatabaseModule } from './database/database.module';
import { SecurityModule } from './security/security.module';
import { DatabaseServerExplorerModule } from './database/database-server-explorer/database-server-explorer.module';
import { DatabaseExplorerComponent } from './database/database-server-explorer/database-explorer/database-explorer.component';
import { DatabaseComponent } from './database/database.component';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,

    DatabaseModule,
    //SecurityModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
