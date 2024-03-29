import { Component, OnInit } from '@angular/core';
import { EmployeerService } from '../services/employeer.service';
import { IJobpost } from './models/IJobpost';
import { JobSeekerService } from '../../job_seeker/services/job-seeker.service';
import { IApplyJob } from '../../job_seeker/services/models/IApplyJob';
import { NgToastService } from 'ng-angular-popup';
import {URLLINKS} from '../../../../environments/urls'
@Component({
  selector: 'app-jobpost',
  templateUrl: './jobpost.component.html',
  styleUrl: './jobpost.component.css'
})
export class JobpostComponent implements OnInit {
  usertypeid: number | null = null;
  constructor(private service: EmployeerService,private jservice: JobSeekerService,private toast:NgToastService) {}
  jobPosts!: IJobpost[];
  post!:IApplyJob
  images:any=URLLINKS.images

  randomImage():string{
    
    return this.images.random()
  }
  ngOnInit(): void {
    const userTypeFromLocalStorage = localStorage.getItem('Type:');
    this.usertypeid = userTypeFromLocalStorage ? +userTypeFromLocalStorage : null;
    this.service.getJobs().subscribe((data) => {
      this.jobPosts = data;
    });
  }
  applyJob(id:any)
  {
    if(localStorage.getItem('Token:'))
    {
      this.post={
        UserAccountId:localStorage.getItem('id:'),
        JobPostId:id,
      }
      this.jservice.applyJob(this.post).subscribe(
        data => {
          this.toast.success({
            detail: "Applied",
            summary: 'Your application has been submitted',
            duration: 2000
          });
        },
        error => {
          this.toast.error({
            detail: "Error",
            summary: 'An error occurred while submitting your application.',
            duration: 3000
          });
        }
      );
      
    }
    else 
    {
      this.toast.error({
        detail: "Error",
        summary: 'Please register yourself to apply!',
        duration: 3000
      });
    }
    }
}
