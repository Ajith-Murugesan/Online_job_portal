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
import { JobApplicationsComponent } from './features/employeer/job-applications/job-applications.component';
import { JobInvitationTemplateComponent } from './features/employeer/job-invitation-template/job-invitation-template.component';
import { EmployeerProfileComponent } from './features/employeer/employeer-profile/employeer-profile.component';
import { InterviewInvitesComponent } from './features/job_seeker/interview-invites/interview-invites.component';
import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [
  {path: 'dashboard', component:DashboardComponent,canActivate: [AuthGuard]},
  {path: 'register', component:RegisterComponent},
  {path: 'login', component:LoginComponent},
  {path: 'jobseekerprofile', component:JobseekerprofileComponent,canActivate: [AuthGuard] },
  {path: 'jobseekerprofile/:id', component:JobseekerprofileComponent,canActivate: [AuthGuard]},
  {path: 'landingpage', component:LandingpageComponent},
  {path: '', component:LandingpageComponent},
  {path: 'sidebar', component:SidebarComponent,canActivate: [AuthGuard]},
  {path: 'approvedusers', component:ApprovedusersComponent,canActivate: [AuthGuard]},
  {path: 'pendingusers', component:PendingusersComponent,canActivate: [AuthGuard]},
  {path: 'passwordreset', component:PasswordresetComponent,canActivate: [AuthGuard]},
  {path: 'companies', component:CompaniesComponent,canActivate: [AuthGuard]},
  {path: 'jobpost', component:JobpostComponent,canActivate: [AuthGuard]},
  {path: 'empnavbar', component:EmployeernavbarComponent,canActivate: [AuthGuard]},
  {path: 'jobseekernavbar', component:JobseekernavbarComponent,canActivate: [AuthGuard]},
  {path: 'appliedjobs', component:AppliedJobsComponent,canActivate: [AuthGuard]},
  {path: 'feedback', component:FeedbackmodalComponent,canActivate: [AuthGuard]},
  {path: 'addjob', component:AddJobpostComponent,canActivate: [AuthGuard]},
  {path: 'managejob', component:ManageJobpostComponent,canActivate: [AuthGuard]},
   {path: 'jobapplications', component:JobApplicationsComponent,canActivate: [AuthGuard]},
   {path: 'mailinvite', component:JobInvitationTemplateComponent,canActivate: [AuthGuard]},
   {path: 'empprofile/:id', component:EmployeerProfileComponent,canActivate: [AuthGuard]},
   {path: 'invites', component:InterviewInvitesComponent,canActivate: [AuthGuard]},
 
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
