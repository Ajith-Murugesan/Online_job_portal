import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { JobseekerprofileComponent } from './job_seeker/jobseekerprofile/jobseekerprofile.component';
import { PasswordresetComponent } from './passwordreset/passwordreset.component';
import { JobpostComponent } from './employeer/jobpost/jobpost.component';
import { AppliedJobsComponent } from './job_seeker/applied-jobs/applied-jobs.component';
import { AddJobpostComponent } from './employeer/add-jobpost/add-jobpost.component';
import { ManageJobpostComponent } from './employeer/manage-jobpost/manage-jobpost.component';



@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    JobseekerprofileComponent,
    PasswordresetComponent,
    JobpostComponent,
    AppliedJobsComponent,
    AddJobpostComponent,
    ManageJobpostComponent
  ],
  imports: [
    CommonModule
  ]
})
export class FeaturesModule { }
