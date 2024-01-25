import { Component, OnInit } from '@angular/core';
import { JobSeekerService } from '../services/job-seeker.service';
import { IJobpost } from '../../employeer/jobpost/models/IJobpost';

@Component({
  selector: 'app-applied-jobs',
  templateUrl: './applied-jobs.component.html',
  styleUrl: './applied-jobs.component.css'
})
export class AppliedJobsComponent implements OnInit{
  constructor(private jservice: JobSeekerService) {}
  jobPosts!: IJobpost[];
  ngOnInit(): void {
    this.jservice.appliedJobs(localStorage.getItem('id:')).subscribe((data) => {
      this.jobPosts = data;
      console.log(data)
    });
  }
}
