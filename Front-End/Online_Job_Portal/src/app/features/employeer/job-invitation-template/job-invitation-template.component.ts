import { Component, Input, OnInit } from '@angular/core';
import { EmployeerService } from '../services/employeer.service';
import { ICompany } from '../jobpost/models/ICompany';
import { NgToastService } from 'ng-angular-popup';
import { ILocation } from '../jobpost/models/ILocation';
import { IInvite } from '../jobpost/models/IInvite';

@Component({
  selector: 'app-job-invitation-template',
  templateUrl: './job-invitation-template.component.html',
  styleUrls: ['./job-invitation-template.component.css'],
})
export class JobInvitationTemplateComponent implements OnInit {
  @Input() userAccountId: number | undefined;
  @Input() jobPostId: number | undefined;
  @Input() jobJobPosition: string | undefined;
  @Input() userName: string | undefined;
  constructor(
    private service: EmployeerService,
    private toast: NgToastService
  ) {
    console.log('popup', this.userAccountId);
  }
  company!: ICompany;
  locations!: ILocation[];

  jobPost: IInvite = {
    JobPostId: 0,
    UserAccountId: 0,
    CompanyId:0,
    CompanyName: '',
    InterviewTime: '',
    InterviewDate: '',
    JobDescription: '',
    LocationId: 0,
    JobPosition: '',
    UserName:'',
    LocationName: ''
  };
  ngOnInit(): void {
    console.log('popup', this.userAccountId);

    this.service.getCompanyByEmployeer(localStorage.getItem('id:')).subscribe((data) => {
      this.company = data;
      console.log("company",data)
    });
    this.service.getlocations().subscribe((data) => {
      this.locations = data;
    });
  }
  submitForm() {
    this.jobPost = {
      JobPostId: this.jobPostId,
      UserAccountId: this.userAccountId,
      CompanyName: this.jobPost.CompanyName,
      InterviewTime: this.jobPost.InterviewTime,
      InterviewDate: this.jobPost.InterviewDate,
      JobDescription: this.jobPost.JobDescription,
      LocationName: this.jobPost.LocationId,
      JobPosition: this.jobJobPosition,
      LocationId:this.locations.find(dt=>dt.City===this.jobPost.LocationId)?.LocationId,
      UserName:this.userName,
      CompanyId:this.company.CompanyId
    };
    this.service.createEmailInvite( this.jobPost).subscribe(dt=>{console.log("Invited and stored")})
    console.log(this.jobPost)
    this.service.getUser(this.userAccountId).subscribe(
      (data) => {
        const email = data.Email;
        console.log(email, 'email');
        console.log('Informations', data);

        this.service
          .sendMailInvite(email, this.jobPost)
          .subscribe(
            (response) => {
            
              this.toast.success({
                detail: 'SUCCESS',
                summary: 'Invited Successfully',
                duration: 2000,
              });
            },
            (error) => {
              this.toast.error({
                detail: 'SORRY',
                summary: 'Unable to send invite',
                duration: 3000,
              });
            }
          );
          this.resetForm();
      },
      (error) => {
        console.error('Error fetching user data:', error);
      }
    );

    
  }
  resetForm() {
    this.jobPost = {
      JobPostId: 0,
      UserAccountId: 0,
      CompanyId:0,
      UserName:'',
      CompanyName: '',
      InterviewTime: '',
      InterviewDate: '',
      JobDescription: '',
      LocationId: 0,
      JobPosition: '',
      LocationName:''
    };
  }
}
