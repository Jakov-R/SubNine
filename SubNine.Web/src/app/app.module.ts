import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AthleteListComponent } from './athletes/athlete-list/athlete-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AthleteDetailComponent } from './athletes/athlete-detail/athlete-detail.component';
import { ClubListComponent } from './clubs/club-list/club-list.component';
import { ClubDetailComponent } from './clubs/club-detail/club-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    AthleteListComponent,
    AthleteDetailComponent,
    ClubListComponent,
    ClubDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
