import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Country } from './country';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor (
    private http: HttpClient
  ) { }

  getCountries(params = {}) {
    // GET req na localhost:5001/api/countries?search=abc
    return this.http.get<Country[]>(environment.apiUrl + '/countries', { params });
  }

  getCountry(id: number) {
    return this.http.get<Country>(environment.apiUrl + '/countries/' + id);
  }

  deleteCountry(id: number) {
    return this.http.delete(environment.apiUrl + '/countries/' + id);
  }
}