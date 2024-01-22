import { NgModule } from '@angular/core';
import {
  BrowserModule,
  provideClientHydration,
} from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './features/admin/components/dashboard/dashboard.component';
import { NavbarComponent } from './layout/components/navbar/navbar.component';
import { SidebarComponent } from './features/admin/components/sidebar/sidebar.component';
import { RegisterComponent } from './features/register/register.component';
import { LoginComponent } from './features/login/login.component';
import { ApprovedusersComponent } from './features/admin/components/approvedusers/approvedusers.component';
import { PendingusersComponent } from './features/admin/components/pendingusers/pendingusers.component';
import { JobseekerprofileComponent } from './features/job_seeker/jobseekerprofile/jobseekerprofile.component';
import { LandingpageComponent } from './core/components/landingpage/landingpage.component';
import { AdminnavbarComponent } from './layout/components/adminnavbar/adminnavbar.component';
import { PasswordresetComponent } from './features/passwordreset/passwordreset.component';
import { CompaniesComponent } from './core/components/companies/companies.component';
import { JobpostComponent } from './features/employeer/jobpost/jobpost.component';
import { EmployeernavbarComponent } from './layout/components/employeernavbar/employeernavbar.component';
import { JobseekernavbarComponent } from './layout/components/jobseekernavbar/jobseekernavbar.component';
import { FeedbackmodalComponent } from './features/admin/components/feedbackmodal/feedbackmodal.component';
import { AppliedJobsComponent } from './features/job_seeker/applied-jobs/applied-jobs.component';
import { AddJobpostComponent } from './features/employeer/add-jobpost/add-jobpost.component';
import { ManageJobpostComponent } from './features/employeer/manage-jobpost/manage-jobpost.component';
import { NgToastModule } from 'ng-angular-popup';
import { JobApplicationsComponent } from './features/employeer/job-applications/job-applications.component';
import { JobInvitationTemplateComponent } from './features/employeer/job-invitation-template/job-invitation-template.component';
@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    NavbarComponent,
    SidebarComponent,
    RegisterComponent,
    LoginComponent,
    ApprovedusersComponent,
    PendingusersComponent,
    JobseekerprofileComponent,
    LandingpageComponent,
    AdminnavbarComponent,
    PasswordresetComponent,
    CompaniesComponent,
    JobpostComponent,
    EmployeernavbarComponent,
    JobseekernavbarComponent,
    FeedbackmodalComponent,
    AppliedJobsComponent,
    AddJobpostComponent,
    ManageJobpostComponent,
    JobApplicationsComponent,
    JobInvitationTemplateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    NgToastModule,
  ],
  providers: [provideClientHydration()],
  bootstrap: [AppComponent],
})
export class AppModule {}
