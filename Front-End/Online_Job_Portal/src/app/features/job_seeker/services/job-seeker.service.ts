import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IApplyJob } from './models/IApplyJob';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { IJobpost } from '../../employeer/jobpost/models/IJobpost';

@Injectable({
  providedIn: 'root'
})
export class JobSeekerService {

  constructor(private httpClient: HttpClient) {}

  applyJob(post:IApplyJob):Observable<IApplyJob> {
    return this.httpClient.post<IApplyJob>(environment.API_endpoints.applyJob,post);
  }
  appliedJobs(id:any):Observable<IJobpost[]> {
    return this.httpClient.get<IJobpost[]>(environment.API_endpoints.appliedJobs+id);
  }
}
