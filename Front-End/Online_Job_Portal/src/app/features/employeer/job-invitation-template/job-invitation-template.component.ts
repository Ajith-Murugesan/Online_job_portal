import { Component } from '@angular/core';
import { EmployeerService } from '../services/employeer.service';
import { ICompany } from '../jobpost/models/ICompany';
import { NgToastService } from 'ng-angular-popup';
import { IAddJob } from '../jobpost/models/IAddJob';
import { ILocation } from '../jobpost/models/ILocation';

@Component({
  selector: 'app-job-invitation-template',
  templateUrl: './job-invitation-template.component.html',
  styleUrl: './job-invitation-template.component.css'
})
export class JobInvitationTemplateComponent {
  constructor(private service:EmployeerService,private toast:NgToastService) {}
  company!:ICompany[]
  locations!:ILocation[]
  jobPost: IAddJob ={
    JobPostId: 0,
    UserAccountId: localStorage.getItem('id'),
    CompanyId: 0,
    JobTypeId: 0,
    JobTitle: '',
    JobDescription: '',
    LocationId: 0,

  }
  ngOnInit(): void {
    this.service.getCompanies().subscribe((data) => {
      this.company = data;
    });
    this.service.getlocations().subscribe((data) => {
      this.locations = data;
    });
  }
  submitForm() {
    this.service.postJob(this.jobPost).subscribe(
      data => {
        this.toast.success({
          detail: "SUCCESS",
          summary: 'New opening created',
          duration: 2000
        });
      },
      error => {
        this.toast.error({
          detail: "SORRY",
          summary: 'Unable to create new opening',
          duration: 3000
        });
      }
    );
    
    
  }
}
