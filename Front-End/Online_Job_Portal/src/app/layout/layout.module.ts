import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AdminnavbarComponent } from './components/adminnavbar/adminnavbar.component';
@NgModule({
  declarations: [
    NavbarComponent,
    AdminnavbarComponent
  ],
  imports: [
    CommonModule
  ]
})
export class LayoutModule { }
