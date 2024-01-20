import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { JobseekerprofileComponent } from './job_seeker/jobseekerprofile/jobseekerprofile.component';
import { PasswordresetComponent } from './passwordreset/passwordreset.component';



@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    JobseekerprofileComponent,
    PasswordresetComponent
  ],
  imports: [
    CommonModule
  ]
})
export class FeaturesModule { }
