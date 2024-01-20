import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingpageComponent } from './components/landingpage/landingpage.component';
import { CompaniesComponent } from './components/companies/companies.component';



@NgModule({
  declarations: [
    LandingpageComponent,
    CompaniesComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
