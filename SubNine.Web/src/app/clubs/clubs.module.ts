import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClubRoutingModule } from './club-routing.module';
import { ClubDetailComponent } from './club-detail/club-detail.component';
import { ClubListComponent } from './club-list/club-list.component';


@NgModule({
  declarations: [ClubDetailComponent, ClubListComponent],
  imports: [
    CommonModule,
    ClubRoutingModule
  ]
})
export class ClubsModule { }
