import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { IUserAccount } from './Models/IUserAccount';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class UserAccountService {
  constructor(private httpClient: HttpClient) {}

  getUsers():Observable<IUserAccount[]> {
    return this.httpClient.get<IUserAccount[]>(environment.API_endpoints.userAccount);
  }

  updateUserStatus(id:number):Observable<string> {
    return this.httpClient.put<string>(environment.API_endpoints.updateUserStatus+`UpdateUserStatus/${id}`,id);
  }
}
