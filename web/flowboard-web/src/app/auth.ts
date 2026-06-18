import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { tap } from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http: HttpClient) { }
  login(username: string, password: string) {
    return this.http.post<{ token: string }>('https://localhost:7045/api/auth/login',{username, password})
    .pipe(tap(response => localStorage.setItem('token', response.token)));
  }
  getToken() {
    return localStorage.getItem('token');
  }
  isLoggedIn() {
    return this.getToken() !== null;
  }
  logout() {
    localStorage.removeItem('token');
  }
  register(username: string, password: string) {
    return this.http.post('https://localhost:7045/api/auth/register',{username, password});
  }
}