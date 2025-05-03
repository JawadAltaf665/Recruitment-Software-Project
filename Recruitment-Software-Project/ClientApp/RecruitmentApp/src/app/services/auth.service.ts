import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'https://localhost:7108/api/Recruitment'; 

  constructor(private http: HttpClient) { }

  registrationRequest(data: any): Observable<any> {
    debugger;
    return this.http.post(`${this.baseUrl}/RegistrationRequest`, data);
  }

  authenticationRequest(data: any): Observable<any> {
    debugger;
    return this.http.post(`${this.baseUrl}/AuthenticationRequest`, data);
  }

}
