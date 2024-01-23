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
    this.service.getJobApplicationsbyId(localStorage.getItem('id:')).subscribe((data) => {
      this.jobApplications = data;
      console.log(data)
    });
  }

  onInvite(userAccountId: number) {
    // You can use the userAccountId as needed
    console.log(`Inviting user with UserAccountId: ${userAccountId}`);
  }
  

}
