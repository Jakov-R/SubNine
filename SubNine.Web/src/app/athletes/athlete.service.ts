import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AthleteListRequest } from './athlete-list/athlete-list.request';
import { environment } from 'src/environments/environment';
import { Athlete } from './athlete';

@Injectable({
  providedIn: 'root'
})
export class AthleteService {

  constructor (
    private http: HttpClient
  ) { }

  getAthletes(params = {}) {
    // GET req na localhost:5001/api/athletes?search=abc
    return this.http.get<AthleteListRequest<Athlete>>(environment.apiUrl + '/athletes', { params });
  }

  getAthlete(id) {
    return this.http.get<Athlete>(environment.apiUrl + '/athletes/' + id);
  }

  deleteAthlete(id) {
    return this.http.delete(environment.apiUrl + '/athletes/' + id)
  }
}
