import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RevisionComponent } from './revision/revision.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }   from '@angular/forms';
import { RevisionsListComponent } from './revisions-list/revisions-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { CarInsertComponent } from './car-insert/car-insert.component';
import { APIService } from './APIServices';

@NgModule({
  declarations: [
    RevisionComponent,
    AppComponent,
    RevisionsListComponent,
    CarInsertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [APIService],
  bootstrap: [AppComponent]
})
export class AppModule { }
