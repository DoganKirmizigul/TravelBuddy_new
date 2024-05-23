import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { Observable } from 'rxjs';
import { ILogin, IRegister } from 'src/app/shared/interfaces';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  //#region .. Private Fields ..
  private accountBaseUrl = environment.apiBaseUrl + '/api/account';
  //#endregion

  //#region .. Constructors ..
  constructor(private http: HttpClient) {}

  authenticate(data: ILogin): Observable<any> {
    return this.http.post(this.accountBaseUrl + '/authenticate', data);
  }

  register(
    data: IRegister
  ): Observable<any> {
    return this.http.post(this.accountBaseUrl + '/register', data);
  }

  forgotPassword(email: string): Observable<any> {
    return this.http.post(this.accountBaseUrl + '/forgot-password', {
      email: email,
    });
  }

  resetPassword(
    token: string,
    newPassword: string,
    confirmPassword: string
  ): Observable<any> {
    return this.http.post(this.accountBaseUrl + '/reset-password', {
      token: token,
      newPassword: newPassword,
      confirmPassword: confirmPassword,
    });
  }
}
