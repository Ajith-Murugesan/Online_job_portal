import { AfterViewInit, Component, OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';
import { EmployeerService } from '../services/employeer.service';
import { IJobApplication } from '../jobpost/models/IJobApplication';

@Component({
  selector: 'app-job-applications',
  templateUrl: './job-applications.component.html',
  styleUrl: './job-applications.component.css'
})
export class JobApplicationsComponent implements OnInit,AfterViewInit {
  constructor(private service: EmployeerService,private toast:NgToastService) {}
  ngAfterViewInit(): void {
    this.jobApplications.forEach(job => this.onLoadfn(job.UserAccountId));
    console.log("After viewinit")
  }
  jobApplications!: IJobApplication[];
  ngOnInit(): void {
    this.service.getJobApplicationsbyId(localStorage.getItem('id:')).subscribe((data) => {
      this.jobApplications = data;
      console.log(data)
    });
  }

  onLoadfn(id:number)
  {
    console.log(`Card loaded for UserAccountId: ${id}`);
  }

}
