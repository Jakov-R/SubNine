import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Club } from './club';

@Injectable({
  providedIn: 'root'
})
export class ClubService {

  constructor (
    private http: HttpClient
  ) { }

  getClubs(params = {}) {
    // GET req na localhost:5001/api/clubs?search=abc
    return this.http.get<Club[]>(environment.apiUrl + '/clubs', { params });
  }

  getClub(id: number) {
    return this.http.get<Club>(environment.apiUrl + '/clubs/' + id);
  }

  deleteClub(id: number) {
    return this.http.delete(environment.apiUrl + '/clubs/' + id);
  }
}