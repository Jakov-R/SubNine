import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AthleteListComponent } from './athlete-list/athlete-list.component';
import { AthleteDetailComponent } from './athlete-detail/athlete-detail.component';
import { AthleteFormComponent } from './athlete-form/athlete-form.component';

const routes: Routes = [
  { path: '', component: AthleteListComponent },
  { path: 'new', component: AthleteFormComponent, },
  { path: ':id/edit', component: AthleteFormComponent },
  { path: ':id', component: AthleteDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AthletesRoutingModule { }
