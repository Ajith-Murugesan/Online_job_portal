import { AfterViewInit, Component, OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';
import { EmployeerService } from '../services/employeer.service';
import { IJobApplication } from '../jobpost/models/IJobApplication';

@Component({
  selector: 'app-job-applications',
  templateUrl: './job-applications.component.html',
  styleUrl: './job-applications.component.css'
})
export class JobApplicationsComponent implements OnInit {
  constructor(private service: EmployeerService,private toast:NgToastService) {}
  
  jobApplications!: IJobApplication[];
  ngOnInit(): void {
    if (typeof localStorage !== 'undefined') {
      this.service.getJobApplicationsbyId(localStorage.getItem('id:')).subscribe((data) => {
        this.jobApplications = data;
        console.log(data)
      });
    }
  }

  onReject(userAccountId: number, jp: number) {
    if (confirm("Do you want to reject the application")) {
      this.service.withdrawApplication(userAccountId, jp).subscribe(dt => {
        this.toast.success({
          detail: 'SUCCESS',
          summary: 'Application Rejected',
          duration: 2000,
        });
      }, error => {
        this.toast.error({
          detail: 'SORRY',
          summary: 'Unable to reject the application',
          duration: 2000,
        });
      });
    }
  }
  

}
