import { Component, OnInit } from '@angular/core';
import { EducationaldetailsService } from '../../admin/Services/educationaldetails.service';
import { JwtPayload, jwtDecode } from "jwt-decode";
import { IUserAccount } from '../../admin/Services/Models/IUserAccount';
import { IEducationalDetail } from '../../admin/Services/Models/IEducationalDetail';
import { IExperienceDetails } from '../../admin/Services/Models/IExperienceDetails';
import { IJobSeekerprofile } from '../../register/services/models/IJobSeekerprofile';
import { ActivatedRoute } from '@angular/router';
import { JobSeekerService } from '../services/job-seeker.service';
import { NgToastService } from 'ng-angular-popup';
@Component({
  selector: 'app-jobseekerprofile',
  templateUrl: './jobseekerprofile.component.html',
  styleUrls: ['./jobseekerprofile.component.css'],
})
export class JobseekerprofileComponent implements OnInit {
  UserDetails!: IUserAccount;
  userProfile:any={
    FirstName:'',
    LastName:'',
  }
  educationalDetails!: IEducationalDetail;
  experienceDetails!: IExperienceDetails;
  profile!:IJobSeekerprofile
  userId!:number
  usertypeid:any = null;
  constructor( private toast:NgToastService,private service: EducationaldetailsService,private route: ActivatedRoute,private jservice: JobSeekerService) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.userId = +params.get('id')!;     
      console.log('User ID:', this.userId);
    });
    this.service.getUserById(this.userId).subscribe((data) => {
      this.UserDetails = data;
      localStorage.setItem('id', data.UserAccountId.toString());
    });
    if (typeof localStorage !== 'undefined') {
      this.usertypeid = localStorage.getItem('Type:');
      const cred = this.decodeJwtToken(localStorage.getItem('Token:'));
      this.service.getUser({ Email: cred.Email, Password: cred.Password }).subscribe((data) => {
        this.UserDetails = data;
        localStorage.setItem('id', data.UserAccountId.toString());

      });
     
      this.service.getEducationalDetails(this.userId).subscribe((data) => {
        this.educationalDetails = data;
      });
  
      this.service.getExperienceDetails(this.userId).subscribe((data) => {
        this.experienceDetails = data;
      });
  
      this.service.getJobseekerDetails(this.userId).subscribe((data) => {
        this.profile = data;
      });
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
    console.log(decodedToken)
    return {
      Email: email,
      Password: password
    };
  }

  saveProfile():void {
    this.profile.UserAccountId=localStorage.getItem('id:')
    this.jservice.saveProfileDetails(this.profile).subscribe(
      usr => {
        this.toast.success({
          detail: "SUCCESS",
          summary: 'Personal details saved!',
          duration: 2000
        });
      },
      error => {
        this.toast.error({
          detail: "SORRY",
          summary: 'Try again, After sometime',
          duration: 3000
        });
      }
    );

  }
  saveEducationDetails():void {
    this.educationalDetails.UserAccountId=localStorage.getItem('id:')
    this.jservice.saveEduDetails(this.educationalDetails).subscribe(
      usr => {
        this.toast.success({
          detail: "SUCCESS",
          summary: 'Educational details saved!',
          duration: 2000
        });
      },
      error => {
        this.toast.error({
          detail: "SORRY",
          summary: 'Try again, After sometime',
          duration: 3000
        });
      }
    );
  }
  saveExperience():void {
    this.experienceDetails.UserAccountId=localStorage.getItem('id:')
    this.jservice.saveExperienceDetails(this.experienceDetails).subscribe(
      usr => {
        this.toast.success({
          detail: "SUCCESS",
          summary: 'Experience details saved!',
          duration: 2000
        });
      },
      error => {
        this.toast.error({
          detail: "SORRY",
          summary: 'Try again, After sometime',
          duration: 3000
        });
      }
    );
  }
}
