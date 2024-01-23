import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IApplyJob } from './models/IApplyJob';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { IJobpost } from '../../employeer/jobpost/models/IJobpost';
import { IEducationalDetail } from '../../admin/Services/Models/IEducationalDetail';
import { IJobSeekerprofile } from '../../register/services/models/IJobSeekerprofile';
import { IExperienceDetails } from '../../admin/Services/Models/IExperienceDetails';
import { IInvite } from '../../employeer/jobpost/models/IInvite';
import { IInterviewInvite } from '../../employeer/jobpost/models/IInterviewInvite';

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
  saveEduDetails(post:IEducationalDetail):Observable<IEducationalDetail> {
    return this.httpClient.post<IEducationalDetail>(environment.API_endpoints.saveeducationalDetails,post);
  }
  saveProfileDetails(post:IJobSeekerprofile):Observable<IJobSeekerprofile> {
    return this.httpClient.post<IJobSeekerprofile>(environment.API_endpoints.jobseekerProfileSave,post);
  }
  saveExperienceDetails(post:IExperienceDetails):Observable<IExperienceDetails> {
    return this.httpClient.post<IExperienceDetails>(environment.API_endpoints.saveExperienceDetails,post);
  }
  getInterviewInviteById(id:any):Observable<IInterviewInvite[]> {
    return this.httpClient.get<IInterviewInvite[]>(environment.API_endpoints.getInterviewInviteById+id);
  }
}
