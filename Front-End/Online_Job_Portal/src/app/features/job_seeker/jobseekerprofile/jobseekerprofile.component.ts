import { Component, OnInit } from '@angular/core';
import { EducationaldetailsService } from '../../admin/Services/educationaldetails.service';
import { JwtPayload, jwtDecode } from "jwt-decode";
import { IUserAccount } from '../../admin/Services/Models/IUserAccount';
import { IEducationalDetail } from '../../admin/Services/Models/IEducationalDetail';
import { IExperienceDetails } from '../../admin/Services/Models/IExperienceDetails';
import { IJobSeekerprofile } from '../../register/services/models/IJobSeekerprofile';

@Component({
  selector: 'app-jobseekerprofile',
  templateUrl: './jobseekerprofile.component.html',
  styleUrls: ['./jobseekerprofile.component.css'],
})
export class JobseekerprofileComponent implements OnInit {
  UserDetails!: IUserAccount;
  educationalDetails!: IEducationalDetail;
  experienceDetails!: IExperienceDetails;
  profile!:IJobSeekerprofile

  constructor(private service: EducationaldetailsService) {}

  ngOnInit(): void {
    const cred = this.decodeJwtToken(localStorage.getItem('Token:'));
    this.service.getUser({ Email: cred.Email, Password: cred.Password }).subscribe((data) => {
      this.UserDetails = data;
      localStorage.setItem('id', data.UserAccountId.toString());
    });

    this.service.getEducationalDetails(localStorage.getItem('id')).subscribe((data) => {
      this.educationalDetails = data;
    });

    this.service.getExperienceDetails(localStorage.getItem('id')).subscribe((data) => {
      this.experienceDetails = data;
    });

    this.service.getJobseekerDetails(localStorage.getItem('id')).subscribe((data) => {
      this.profile = data;
    });
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

  saveProfile() {
    alert('clicked');
  }
}
