import { Component, OnInit } from '@angular/core';
import { IJobpost } from '../jobpost/models/IJobpost';
import { EmployeerService } from '../services/employeer.service';
import { NgToastService } from 'ng-angular-popup';
@Component({
  selector: 'app-manage-jobpost',
  templateUrl: './manage-jobpost.component.html',
  styleUrl: './manage-jobpost.component.css'
})
export class ManageJobpostComponent implements OnInit {
  constructor(private service: EmployeerService,private toast:NgToastService) {}
  jobPosts!: IJobpost[];
  ngOnInit(): void {
    this.getAll()
  }
  deleteJob(id:number):void
  {
    if(confirm("Do you want to remove this Job opening"))
    {
      this.service.deleteJob(id).subscribe(
        data => {
          this.toast.success({
            detail: "SUCCESS",
            summary: 'Job opening deleted',
            duration: 2000
          });
          this.getAll();
        },
        error => {
          this.toast.error({
            detail: "ERROR",
            summary: 'Unabled to delete the job opening',
            duration: 3000
          });
        }
      );
    }
  }
  getAll():void{
    this.service.getJobsbyId(localStorage.getItem('id')).subscribe((data) => {
      this.jobPosts = data;
    });
  }
}
