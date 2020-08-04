import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AthleteListComponent } from './athletes/athlete-list/athlete-list.component';
import { AthleteDetailComponent } from './athletes/athlete-detail/athlete-detail.component';
import { ClubListComponent } from './clubs/club-list/club-list.component';
import { ClubDetailComponent } from './clubs/club-detail/club-detail.component';


const routes: Routes = [
  { path: '', component: AthleteListComponent },
  { path: 'athletes', component: AthleteListComponent },
  { path: 'athletes/:id', component: AthleteDetailComponent },
  { path: 'clubs', component: ClubListComponent },
  { path: 'clubs/:id', component: ClubDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
