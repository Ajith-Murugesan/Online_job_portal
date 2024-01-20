import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ApprovedusersComponent } from './components/approvedusers/approvedusers.component';
import { PendingusersComponent } from './components/pendingusers/pendingusers.component';



@NgModule({
  declarations: [
    DashboardComponent,
    SidebarComponent,
    ApprovedusersComponent,
    PendingusersComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AdminModule { }
