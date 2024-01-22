import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
import { LoginService } from '../register/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  isLoggedIn = false;
  User: any = {
    Email: '',
    Pasaword: '',
  };
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private service: LoginService,
    private toast: NgToastService
  ) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.User = {
        Email: this.loginForm.value.email,
        Password: this.loginForm.value.password,
      };
    }
    if (
      this.loginForm.value.email === 'admin@gmail.com' &&
      this.loginForm.value.password === 'Admin@123'
    ) {
      localStorage.setItem('Type:','3')
      this.toast.success({
        detail: 'WELCOME ADMIN',
        summary: 'Successfully logged in',
        duration: 2000,
      });
      this.router.navigate(['/dashboard']);
    } else {
      this.service.Login(this.User).subscribe(
        (response) => {
          if (response.ok) {
            const token = response.body.Token;
            const typeId = response.body.UserTypename;
            const Id = response.body.UserAccountId;
            localStorage.setItem('Token:', token);
            localStorage.setItem('id:', Id);
            localStorage.setItem('Type:', typeId);
            this.toast.success({
              detail: 'WELCOME',
              summary: 'Successfully logged in',
              duration: 2000,
            });
            if (this.loginForm.value.password.length === 15)
              this.router.navigate(['/passwordreset']);
            else {
              // window.location.reload()
              this.router.navigate(['/landingpage'])
            }
          } else {
            this.toast.error({
              detail: 'SORRY',
              summary: 'Invalid credentials',
              duration: 2000,
            });
          }
        },
        (error) => {
          this.toast.error({
            detail: 'SORRY',
            summary: 'Invalid credentials',
            duration: 2000,
          });
        }
      );
    }
  }
  
}
