import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'athletes', loadChildren: () => import('./athletes/athlete.module').then(m => m.AthletesModule) },
  { path: 'clubs', loadChildren: () => import('./clubs/clubs.module').then(m => m.ClubsModule) },
  { path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
