import { Component, OnInit } from '@angular/core';
import { EducationaldetailsService } from '../../admin/Services/educationaldetails.service';

@Component({
  selector: 'app-jobseekerprofile',
  templateUrl: './jobseekerprofile.component.html',
  styleUrl: './jobseekerprofile.component.css',
})
export class JobseekerprofileComponent implements OnInit {
  constructor(private service: EducationaldetailsService) {}
  educationalDetails!: any;
  formProfileFields = [
    {
      name: 'firstName',
      type: 'text',
      label: 'First Name',
      errorMessage: 'First name is required',
     
    },
    {
      name: 'lastName',
      type: 'text',
      label: 'Last Name',
      errorMessage: 'First name is required',
    },
    {
      name: 'email',
      type: 'email',
      label: 'E-mail',
      errorMessage: 'Invalid email address',
    },
    {
      name: 'phone',
      type: 'tel',
      label: 'Phone',
      errorMessage: 'Phone number is required',
    },
  ];
  formEducationalDetailFields = [
    {
      name: 'Degree',
      type: 'text',
      label: 'Degree',
      errorMessage: 'Degree is required',
      value:"educationalDetails.DegreeName"
    },
    {
      name: 'Major',
      type: 'text',
      label: 'Major',
      errorMessage: 'Major is required',
      value:"educationalDetails.Major"
    },
    {
      name: 'Institute Name',
      type: 'text',
      label: 'Institute Name',
      errorMessage: 'Institute Name is required',
      value:"educationalDetails.InstituteName"
    },
    {
      name: 'cgpa',
      type: 'text',
      label: 'CGPA or Percentage',
      errorMessage: 'CGPA or Percentage is required',
      value:"educationalDetails.CGPA"
    },
    {
      name: 'StartedDate',
      type: 'date',
      label: 'Started Date',
      errorMessage: 'Started Date is required',
      value:"educationalDetails.StartingDate"
    },
    {
      name: 'CompletionDate',
      type: 'date',
      label: 'Completion Date',
      errorMessage: 'Completion Dateis required',
      value:"educationalDetails.CompletionDate"
    },
  ];
  formExperienceDetailsFields = [
    {
      name: 'jobTitlte',
      type: 'text',
      label: 'Job Titlte',
      errorMessage: 'Job Titlte is required',
    },
    {
      name: 'companyName',
      type: 'text',
      label: 'Company Name',
      errorMessage: 'Company name is required',
    },
    {
      name: 'startDate',
      type: 'date',
      label: 'Start Date',
      errorMessage: 'Start Date is required',
    },
    {
      name: 'endDate',
      type: 'date',
      label: 'End Date',
      errorMessage: 'End Date is required',
    },
  ];
  
  ngOnInit(): void {
    // this.service.getEducationalDetails(27).subscribe((data) => {
    //   (this.educationalDetails = data), console.log(data);
    // });
  }
  
}
