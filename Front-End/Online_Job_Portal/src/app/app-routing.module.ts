import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './features/admin/components/dashboard/dashboard.component';
import { RegisterComponent } from './features/register/register.component';
import { LoginComponent } from './features/login/login.component';
import { SidebarComponent } from './features/admin/components/sidebar/sidebar.component';
import { JobseekerprofileComponent } from './features/job_seeker/jobseekerprofile/jobseekerprofile.component';
import { LandingpageComponent } from './core/components/landingpage/landingpage.component';
import { ApprovedusersComponent } from './features/admin/components/approvedusers/approvedusers.component';
import { PendingusersComponent } from './features/admin/components/pendingusers/pendingusers.component';
import { PasswordresetComponent } from './features/passwordreset/passwordreset.component';
import { CompaniesComponent } from './core/components/companies/companies.component';
import { JobpostComponent } from './features/employeer/jobpost/jobpost.component';
import { EmployeernavbarComponent } from './layout/components/employeernavbar/employeernavbar.component';
import { JobseekernavbarComponent } from './layout/components/jobseekernavbar/jobseekernavbar.component';
import { FeedbackmodalComponent } from './features/admin/components/feedbackmodal/feedbackmodal.component';
import { AppliedJobsComponent } from './features/job_seeker/applied-jobs/applied-jobs.component';
import { AddJobpostComponent } from './features/employeer/add-jobpost/add-jobpost.component';
import { ManageJobpostComponent } from './features/employeer/manage-jobpost/manage-jobpost.component';
import { AppComponent } from './app.component';
import { NavbarComponent } from './layout/components/navbar/navbar.component';

const routes: Routes = [
  {path: 'dashboard', component:DashboardComponent},
  {path: 'register', component:RegisterComponent},
  {path: 'login', component:LoginComponent},
  {path: 'jobseekerprofile', component:JobseekerprofileComponent},
  {path: 'landingpage', component:LandingpageComponent},
  // {path: '', component:AppComponent},
  {path: 'sidebar', component:SidebarComponent},
  {path: 'approvedusers', component:ApprovedusersComponent},
  {path: 'pendingusers', component:PendingusersComponent},
  {path: 'passwordreset', component:PasswordresetComponent},
  {path: 'companies', component:CompaniesComponent},
  {path: 'jobpost', component:JobpostComponent},
  {path: 'empnavbar', component:EmployeernavbarComponent},
  {path: 'jobseekernavbar', component:JobseekernavbarComponent},
  {path: 'appliedjobs', component:AppliedJobsComponent},
  {path: 'feedback', component:FeedbackmodalComponent},
  {path: 'addjob', component:AddJobpostComponent},
  {path: 'managejob', component:ManageJobpostComponent},
  // {path: '', component:NavbarComponent},
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
