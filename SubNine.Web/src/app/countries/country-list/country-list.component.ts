import { Component, OnInit } from '@angular/core';
import { CountryService } from '../country.service';

import { Country } from '../country';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent implements OnInit {

  countries: Country[] = [];

  constructor(
    private countryService: CountryService
  ) { }

  ngOnInit(): void {
    this.countryService.getCountries({}).subscribe(result => {
      this.countries = result;
    });
  }

}
