import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { IJobpost } from '../jobpost/models/IJobpost';
import { environment } from '../../../../environments/environment';
import { ICompany } from '../jobpost/models/ICompany';
import { IAddJob } from '../jobpost/models/IAddJob';
import { ILocation } from '../jobpost/models/ILocation';
import { IJobApplication } from '../jobpost/models/IJobApplication';
import { IInvite } from '../jobpost/models/IInvite';
import { IUserAccount } from '../../admin/Services/Models/IUserAccount';

@Injectable({
  providedIn: 'root'
})
export class EmployeerService {

  constructor(private httpClient: HttpClient) {}

  getJobs():Observable<IJobpost[]> {
    return this.httpClient.get<IJobpost[]>(environment.API_endpoints.jobPosts);
  }
  getJobsbyId(id:any):Observable<IJobpost[]> {
    return this.httpClient.get<IJobpost[]>(environment.API_endpoints.jobById+id);
  }
  getCompanies():Observable<ICompany[]> {
    return this.httpClient.get<ICompany[]>(environment.API_endpoints.company);
  }
  getCompanyByEmployeer(id:any):Observable<ICompany> {
    return this.httpClient.get<ICompany>(environment.API_endpoints.getCompanyByEmployeer+id);
  }
  getlocations():Observable<ILocation[]> {
    return this.httpClient.get<ILocation[]>(environment.API_endpoints.location);
  }

  postJob(job:IAddJob):Observable<IAddJob> {
    return this.httpClient.post<IAddJob>(environment.API_endpoints.createJob,job);
  }
  deleteJob(id:number):Observable<string> {
    return this.httpClient.delete<string>(environment.API_endpoints.deleteJob+id);
  }
  getJobApplicationsbyId(id:any):Observable<IJobApplication[]> {
    return this.httpClient.get<IJobApplication[]>(environment.API_endpoints.jobApplications+id);
  }
  getUser(id:any):Observable<IUserAccount>
  {
    return this.httpClient.get<IUserAccount>(environment.API_endpoints.getUserEmail+id);
  }
  sendMailInvite(mail: string, info: IInvite): Observable<string> {
    return this.httpClient.post<string>(
      environment.API_endpoints.emailInvite+mail,info);
  }

  createEmailInvite(info: IInvite): Observable<IInvite> {
    return this.httpClient.post<IInvite>(
      environment.API_endpoints.createEmailInvite,info);
  }
  
}
