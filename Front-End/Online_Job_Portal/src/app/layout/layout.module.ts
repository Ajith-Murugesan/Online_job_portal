import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AdminnavbarComponent } from './components/adminnavbar/adminnavbar.component';
import { EmployeernavbarComponent } from './components/employeernavbar/employeernavbar.component';
import { JobseekernavbarComponent } from './components/jobseekernavbar/jobseekernavbar.component';
@NgModule({
  declarations: [
    NavbarComponent,
    AdminnavbarComponent,
    EmployeernavbarComponent,
    JobseekernavbarComponent
  ],
  imports: [
    CommonModule
  ]
})
export class LayoutModule { }
