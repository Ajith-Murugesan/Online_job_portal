import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from './services/register.service';
import { IRegister } from './services/models/IRegister';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registrationForm!: FormGroup;
  User: IRegister = {
    UserName: '', // Initialize with empty string
    UserTypeId: 0,
    Email: '',
    ContactNumber: 0
  };
  formFields = [
    {
      name: 'firstName',
      type: 'text',
      label: 'User name',
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
    }
  ];
  isSubmitted = false;

  constructor(private formBuilder: FormBuilder, private service: RegisterService,private router: Router) {}

  ngOnInit() {
    this.registrationForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      userType: ['Applicant', Validators.required], // Added with default value
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      this.User = {
        UserName: this.registrationForm.value.firstName,
        UserTypeId: this.registrationForm.value.userType === 'Applicant' ? 1 : 2,
        Email: this.registrationForm.value.email,
        ContactNumber: this.registrationForm.value.phone
      };

      const res=this.service.createUsers(this.User).subscribe(usr => {
        console.log(usr);
        alert("New user added successfully!!!");
      });
      this.router.navigate(['/login']);
      this.isSubmitted = true;
    }
  }
}
