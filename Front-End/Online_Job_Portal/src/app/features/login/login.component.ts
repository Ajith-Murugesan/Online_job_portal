import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { LoginService } from '../register/services/login.service';
import { response } from 'express';
import { error } from 'console';
import { HttpErrorResponse } from '@angular/common/http';

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
    private toastr: ToastrService,
    private router: Router,
    private service: LoginService
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
    
    this.service.Login(this.User).subscribe(
      response => {  
        if (response.ok) {
          const token = response.body.Token;
          console.log(token)
          sessionStorage.setItem('Token:', token);
          alert("Successfully logged in")
          this.router.navigate(['/landingpage']);
        } else {
         
          console.error('Login failed:', response.status, response.statusText);
        }
      },
      error => {
        alert("Invalid credentials in")
        console.error('Login failed:', error);
      }
    );
    
    


  }
}
