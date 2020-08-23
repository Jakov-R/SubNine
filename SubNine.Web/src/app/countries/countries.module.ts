import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CountryRoutingModule } from './country-routing.module';
import { CountryDetailComponent } from './country-detail/country-detail.component';
import { CountryListComponent } from './country-list/country-list.component';


@NgModule({
  declarations: [CountryDetailComponent, CountryListComponent],
  imports: [
    CommonModule,
    CountryRoutingModule
  ]
})
export class CountriesModule { }
