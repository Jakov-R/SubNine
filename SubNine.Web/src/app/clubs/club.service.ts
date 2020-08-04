import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Club } from './club';

@Injectable({
  providedIn: 'root'
})
export class ClubService {

  constructor (
    private http: HttpClient
  ) { }

  getClubs(params = {}) {
    return this.http.get<Club[]>(environment.apiUrl + '/clubs', { params });
  }

  getClub(id) {
    return this.http.get<Club>(environment.apiUrl + '/clubs/' + id);
  }
}
