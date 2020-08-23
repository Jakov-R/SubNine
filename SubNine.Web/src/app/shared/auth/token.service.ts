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

    setUser(user = {}) {
        localStorage.setItem('user', JSON.stringify(user));
    }

    getUser() {
        let user = localStorage.getItem('user');
        if(user) { return JSON.parse(user); }
        return null;
    }
}