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

const routes: Routes = [
  {path: 'dashboard', component:DashboardComponent},
  {path: 'register', component:RegisterComponent},
  {path: 'login', component:LoginComponent},
  {path: 'jobseekerprofile', component:JobseekerprofileComponent},
  {path: 'landingpage', component:LandingpageComponent},
  {path: '', component:LandingpageComponent},
  {path: 'sidebar', component:SidebarComponent},
  {path: 'approvedusers', component:ApprovedusersComponent},
  {path: 'pendingusers', component:PendingusersComponent},
  {path: 'passwordreset', component:PasswordresetComponent},
  {path: 'companies', component:CompaniesComponent},

 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
