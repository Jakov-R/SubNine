import { NgModule } from '@angular/core';

import { AthletesRoutingModule } from './athlete-routing.module';
import { AthleteListComponent } from './athlete-list/athlete-list.component';
import { AthleteDetailComponent } from './athlete-detail/athlete-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { AthleteFormComponent } from './athlete-form/athlete-form.component';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';

import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [AthleteListComponent, AthleteDetailComponent, AthleteFormComponent],
  imports: [
    SharedModule,
    RouterModule,
    ToastrModule.forRoot(),
    AthletesRoutingModule,
    NgxPaginationModule
  ]
})
export class AthletesModule { }