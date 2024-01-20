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
import { ToastrModule } from 'ngx-toastr';
import { AdminnavbarComponent } from './layout/components/adminnavbar/adminnavbar.component';
import { PasswordresetComponent } from './features/passwordreset/passwordreset.component';
import { CompaniesComponent } from './core/components/companies/companies.component';
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
    CompaniesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
  ],
  providers: [provideClientHydration()],
  bootstrap: [AppComponent],
})
export class AppModule {}
