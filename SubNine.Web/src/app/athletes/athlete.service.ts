import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Athlete } from './athlete';
import { AthleteListResponse } from './athlete-list/athlete-list.response';
import { Operation } from 'fast-json-patch';

@Injectable({
  providedIn: 'root'
})
export class AthleteService {

  constructor (
    private http: HttpClient
  ) { }

  getAthletes(params = {}) {
    // GET req na localhost:5001/api/athletes?search=abc
    return this.http.get<AthleteListResponse>(environment.apiUrl + '/athletes', { params });
  }

  saveAthlete(athlete: Athlete) {
    if(athlete.id) { return this.putAthlete(athlete); }
    return this.postAthlete(athlete);
  }

  getAthlete(id: number) {
    return this.http.get<Athlete>(environment.apiUrl + '/athletes/' + id);
  }

  deleteAthlete(id: number) {
    return this.http.delete(environment.apiUrl + '/athletes/' + id);
  }

  postAthlete(athlete: Athlete) {
    return this.http.post<Athlete>(environment.apiUrl + '/athletes', athlete);
  }

  patchAthlete(id: number, patches: Operation[]) {
    return this.http.patch<Athlete>(environment.apiUrl + '/athletes/' + id, patches);
  }

  putAthlete(athlete: Athlete) {
    return this.http.put<Athlete>(environment.apiUrl + '/athletes/' + athlete.id, athlete);
  }
}