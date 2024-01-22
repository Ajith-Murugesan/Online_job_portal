import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { IUserAccount } from './Models/IUserAccount';
import { Observable } from 'rxjs';
import { IUpdatestatus } from './Models/IUpdatestatus';
import { IFeedback } from './Models/IFeedback';
@Injectable({
  providedIn: 'root',
})
export class UserAccountService {
  constructor(private httpClient: HttpClient) {}

  getUsers():Observable<IUserAccount[]> {
    return this.httpClient.get<IUserAccount[]>(environment.API_endpoints.userAccount);
  }

  updateUserStatus(info:IUpdatestatus):Observable<string> {
    return this.httpClient.put<string>(environment.API_endpoints.updateUserStatus+`UpdateUserStatus/${info.UserAccountId}`,info);
  }

  deleteUserStatus(info:IFeedback): Observable<string> {
    return this.httpClient.delete<string>(environment.API_endpoints.deleteUser, {
      body: info
    });
  }
  
}
