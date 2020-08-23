import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { LoginResponse } from './login/login.response';
import { LoginRequest } from './login/login.request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor (
    private http: HttpClient
  ) { }

  login(params: LoginRequest) {
    return this.http.post<LoginResponse>(environment.apiUrl + '/auth/login', params);
  }
}