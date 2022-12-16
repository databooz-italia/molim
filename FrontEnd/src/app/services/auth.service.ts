import { Injectable, Inject } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import {
  AuthClient,
  IAuthenticationRequest,
  AuthenticationRequest,
  AuthenticationResponse,
  IResetPasswordRequest,
  ResetPasswordRequest
} from './api.client';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(@Inject(AuthClient) private authClient: AuthClient) { }

  login(request: IAuthenticationRequest, remember: boolean): Observable<boolean> {
    return this.authClient.authenticate(new AuthenticationRequest(request))
      .pipe(map((result: AuthenticationResponse) => {
        if (result) {
          this.setSession(remember ? result.longTermToken : result.shortTermToken, result.username, result.roleType, result.permissions, result.resetPassword);
        }

        return true;
      }));
  }

  resetPassword(request: IResetPasswordRequest) {
    return this.authClient.resetPassword(new ResetPasswordRequest(request))
      .pipe(map((result) => {
        localStorage.removeItem('resetPassword');

        return true;
      }));
  }

  private setSession(token, username, role, permissions, resetPassword) {
    localStorage.setItem('lastToken', JSON.stringify(token));
    localStorage.setItem('user', JSON.stringify({ username, role, permissions }));
    localStorage.setItem('resetPassword', JSON.stringify(resetPassword));
  }

  removeSession(removeUser: boolean) {
    localStorage.removeItem('lastToken');

    if (removeUser)
      localStorage.removeItem('user');
  }

  isLogged() {
    let token = localStorage.getItem('lastToken');

    return token != undefined && token != null && token != '';
  }

  loggedUsername() {
    let loggedUserData = JSON.parse(localStorage.getItem('user'));

    if (this.isLogged() && loggedUserData)
      return loggedUserData.username;

    return undefined;
  }

  loggedRole() {
    let loggedUserData = JSON.parse(localStorage.getItem('user'));

    if (this.isLogged() && loggedUserData)
      return loggedUserData.role;

    return undefined;
  }

  checkLoggedRolePermission(permission: string): boolean {
    let loggedUserData = JSON.parse(localStorage.getItem('user'));

    if (this.isLogged() && loggedUserData && loggedUserData.permissions) {
      let foundPermission = loggedUserData.permissions.find((x: string) => x.toLowerCase() == permission.toLowerCase());
      return foundPermission != undefined && foundPermission != null;
    }

    return false;
  }

  mustResetPassword(): boolean {
    let resetPassword = localStorage.getItem('resetPassword');

    return JSON.parse(resetPassword) == true;
  }
}
