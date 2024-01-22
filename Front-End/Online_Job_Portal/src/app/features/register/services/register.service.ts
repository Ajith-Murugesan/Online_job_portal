import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegister } from './models/IRegister';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../../../environments/environment';
import { IResetPassword } from './models/IResetPassword';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpClient: HttpClient) {}

  createUsers(user:IRegister):Observable<IRegister> {
    return this.httpClient.post<IRegister>(environment.API_endpoints.updateUserStatus+"CreateUser",user);
  }

  resetPassword(user:IResetPassword):Observable<IResetPassword> {
    return this.httpClient.put<IResetPassword>(environment.API_endpoints.resetPassword,user);
  }

}
