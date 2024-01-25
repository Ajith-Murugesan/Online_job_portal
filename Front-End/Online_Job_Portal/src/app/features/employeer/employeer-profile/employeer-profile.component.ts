import { Component, OnInit } from '@angular/core';
import { JwtPayload, jwtDecode } from 'jwt-decode';
import { IUserAccount } from '../../admin/Services/Models/IUserAccount';
import { IEducationalDetail } from '../../admin/Services/Models/IEducationalDetail';
import { IJobSeekerprofile } from '../../register/services/models/IJobSeekerprofile';
import { IExperienceDetails } from '../../admin/Services/Models/IExperienceDetails';
import { EducationaldetailsService } from '../../admin/Services/educationaldetails.service';
import { ActivatedRoute } from '@angular/router';
import { JobSeekerService } from '../../job_seeker/services/job-seeker.service';
import { NgToastService } from 'ng-angular-popup';
import { ICompany } from '../jobpost/models/ICompany';
import { IStream } from '../jobpost/models/IStream';
import { EmployeerService } from '../services/employeer.service';

@Component({
  selector: 'app-employeer-profile',
  templateUrl: './employeer-profile.component.html',
  styleUrl: './employeer-profile.component.css',
})
export class EmployeerProfileComponent implements OnInit {
  companyStream!:IStream[]
  cmp:ICompany={
    CompanyId: 0,
    CompanyName: '',
    StreamId: 0,
    CompanyDescription: '',
    WebsiteUrl: '',
    CompanyImage: '',
    UserAccountId: 0
  }
  UserDetails: IUserAccount={
    UserAccountId: 0,
    UserName: '',
    UserTypeId: 0,
    Email: '',
    Password: '',
    UserDOB: new Date(),
    Gender: '',
    IsActive: false,
    ContactNumber: 0,
    UserImage: '',
    RegistrationDate: new Date()
  };
  userProfile: any = {
    FirstName: '',
    LastName: '',
  };
  companyDetails: ICompany={
    CompanyName: "",
    CompanyId: 0,
    StreamId: 0,
    CompanyDescription: '',
    WebsiteUrl: '',
    CompanyImage: '',
    UserAccountId: 0
  };
  profile!: IJobSeekerprofile;
  userId!: number;
  constructor(
    private toast: NgToastService,
    private service: EducationaldetailsService,
    private route: ActivatedRoute,
    private jservice: JobSeekerService,
    private eService:EmployeerService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.userId = +params.get('id')!;
      console.log('User ID:', this.userId);
    });
    if (typeof localStorage !== 'undefined') {
      const cred = this.decodeJwtToken(localStorage.getItem('Token:'));
      this.service
      .getUser({ Email: cred.Email, Password: cred.Password })
      .subscribe((data) => {
        this.UserDetails = data;
        localStorage.setItem('id', data.UserAccountId.toString());
      });
      this.service.getJobseekerDetails(this.userId).subscribe((data) => {
        this.profile = data;
      });
      this.jservice.getAllstreams().subscribe((data) => {
        this.companyStream = data;
      });
      this.eService.getCompanyByEmployeer(this.userId).subscribe(dt=>{
        this.cmp=dt
        console.log(this.cmp)
      })
    }
    
    
  }

  decodeJwtToken(token: any): any {
    interface DecodedToken extends JwtPayload {
      Email: string;
      Password: string;
    }
    const decodedToken: DecodedToken = jwtDecode(token);
    const email = decodedToken.Email;
    const password = decodedToken.Password;
    console.log(decodedToken);
    return {
      Email: email,
      Password: password,
    };
  }

  saveProfile(): void {
    if (typeof localStorage !== 'undefined') {
      this.profile.UserAccountId = this.userId;
      this.jservice.saveProfileDetails(this.profile).subscribe(
        (usr) => {
          this.toast.success({
            detail: 'SUCCESS',
            summary: 'Personal details saved!',
            duration: 2000,
          });
        },
        (error) => {
          this.toast.error({
            detail: 'SORRY',
            summary: 'Try again, After sometime',
            duration: 3000,
          });
        }
      );
    }
   
  }
  saveEducationalDetail(): void {
    if (typeof localStorage !== 'undefined') {
    this.companyDetails.UserAccountId = localStorage.getItem('id:');
    this.jservice.saveCompanyDetails(this.companyDetails).subscribe(
      (usr) => {
        this.toast.success({
          detail: 'SUCCESS',
          summary: 'Company details saved!',
          duration: 2000,
        });
      },
      (error) => {
        this.toast.error({
          detail: 'SORRY',
          summary: 'Try again, After sometime',
          duration: 3000,
        });
      }
    );
  }
    }
    
  
}
