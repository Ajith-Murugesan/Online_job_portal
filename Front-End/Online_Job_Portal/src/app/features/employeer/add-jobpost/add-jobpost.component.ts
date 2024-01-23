import { Component, OnInit } from '@angular/core';
import { IJobpost } from '../jobpost/models/IJobpost';
import { ICompany } from '../jobpost/models/ICompany';
import { EmployeerService } from '../services/employeer.service';
import { IAddJob } from '../jobpost/models/IAddJob';
import { ILocation } from '../jobpost/models/ILocation';
import { NgToastService } from 'ng-angular-popup';
@Component({
  selector: 'app-add-jobpost',
  templateUrl: './add-jobpost.component.html',
  styleUrls: ['./add-jobpost.component.css']
})
export class AddJobpostComponent implements OnInit {

  constructor(private service:EmployeerService,private toast:NgToastService) {}
  company!:ICompany
  locations!:ILocation[]
  jobPost: IAddJob ={
    JobPostId: 0,
    UserAccountId: localStorage.getItem('id:'),
    CompanyId: 0,
    JobTypeId: 0,
    JobTitle: '',
    JobDescription: '',
    LocationId: 0,

  }
  ngOnInit(): void {
    this.service.getCompanyByEmployeer(localStorage.getItem('id:')).subscribe((data) => {
      this.company = data;
      console.log("company",data)
    });
    this.service.getlocations().subscribe((data) => {
      this.locations = data;
    });
  }
  submitForm() {
    this.jobPost.CompanyId=this.company.CompanyId
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
    
    this.resetForm()
  }
  resetForm() {
    this.jobPost = {
      JobPostId: 0,
      UserAccountId: '',
      CompanyId: 0,
      JobTypeId: 0,
      JobTitle: '',
      JobDescription: '',
      LocationId: 0,
    };
}
}
