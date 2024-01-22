import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { IJobpost } from '../jobpost/models/IJobpost';
import { environment } from '../../../../environments/environment';
import { ICompany } from '../jobpost/models/ICompany';
import { IAddJob } from '../jobpost/models/IAddJob';
import { ILocation } from '../jobpost/models/ILocation';
import { IJobApplication } from '../jobpost/models/IJobApplication';

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
}
