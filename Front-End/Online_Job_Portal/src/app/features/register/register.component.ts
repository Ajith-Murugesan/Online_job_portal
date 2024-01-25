import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from './services/register.service';
import { IRegister } from './services/models/IRegister';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  userTypeid: any = '1';
  registrationForm!: FormGroup;
  User: IRegister = {
    UserName: '',
    UserTypeId: 0,
    Email: '',
    ContactNumber: 0,
    message: '',
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
      errorMessage: 'Invalid phone number',
    },
  ];
  isSubmitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private service: RegisterService,
    private router: Router,
    private toast: NgToastService
  ) {}

  ngOnInit() {
    console.log('Event');

    this.registrationForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      userType: [1, Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      this.User = {
        UserName: this.registrationForm.value.firstName,
        UserTypeId: this.registrationForm.value.userType,
        Email: this.registrationForm.value.email,
        ContactNumber: this.registrationForm.value.phone,
        message: '',
      };
      this.service.createUsers(this.User).subscribe(
        (usr) => {
          const mag = usr.message === 'Email already exists!';
          if (mag) {
            this.toast.error({
              detail: 'SORRY',
              summary: 'Email already exists!',
              duration: 3000,
            });
          } else {
            this.toast.success({
              detail: 'WELCOME',
              summary: 'Registered Successfully',
              duration: 2000,
            });
            this.router.navigate(['/login']);
          }
        },
        (error) => {
          this.toast.error({
            detail: 'SORRY',
            summary: 'Registration failed',
            duration: 3000,
          });
        }
      );

      this.isSubmitted = true;
    }
  }
}
