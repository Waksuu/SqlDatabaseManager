import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ConnectionModule } from './connection/connection.module';
import { DatabaseModule } from './database/database.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,

    DatabaseModule,
    ConnectionModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
