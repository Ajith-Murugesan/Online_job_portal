import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IEducationalDetail } from './Models/IEducationalDetail';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ILogin } from '../../register/services/models/ILogin';
import { IUserAccount } from './Models/IUserAccount';
import { IExperienceDetails } from './Models/IExperienceDetails';
import { IJobSeekerprofile } from '../../register/services/models/IJobSeekerprofile';

@Injectable({
  providedIn: 'root'
})
export class EducationaldetailsService {

  constructor(private httpClient: HttpClient) {}

  getAllEducationalDetails():Observable<IEducationalDetail[]> {
    return this.httpClient.get<IEducationalDetail[]>(environment.API_endpoints.educationalDetails+"GetAll");
  }

  getEducationalDetails(id:any):Observable<IEducationalDetail> {
    return this.httpClient.get<IEducationalDetail>(environment.API_endpoints.educationalDetails+id);
  }

  getUser(usr:ILogin):Observable<IUserAccount> {
    return this.httpClient.get<IUserAccount>(`https://localhost:7119/UserAccount/GetUser?Email=${usr.Email}&Password=${usr.Password}`);
  }

  getExperienceDetails(id:any):Observable<IExperienceDetails> {
    return this.httpClient.get<IExperienceDetails>(environment.API_endpoints.experienceDetails+id);
  }

  getJobseekerDetails(id:any):Observable<IJobSeekerprofile> {
    return this.httpClient.get<IJobSeekerprofile>(environment.API_endpoints.jobSeekerProfile+id);
  }
}
