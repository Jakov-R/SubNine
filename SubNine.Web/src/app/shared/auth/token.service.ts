import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class TokenService {

    tokenName: string = 'auth-token';

    constructor(
        private http: HttpClient
    ) { }

    setToken(token: string) {
        localStorage.setItem(this.tokenName, token);
    }

    getToken() {
        return localStorage.getItem(this.tokenName);
    }
}