import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegister } from './models/IRegister';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpClient: HttpClient) {}

  createUsers(user:IRegister):Observable<IRegister> {
    return this.httpClient.post<IRegister>(environment.API_endpoints.updateUserStatus+"CreateUser",user);
  }
}
