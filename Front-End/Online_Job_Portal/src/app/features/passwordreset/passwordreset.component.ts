import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { JwtPayload, jwtDecode } from "jwt-decode";
import { RegisterService } from '../register/services/register.service';
import { IResetPassword } from '../register/services/models/IResetPassword';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-passwordreset',
  templateUrl: './passwordreset.component.html',
  styleUrl: './passwordreset.component.css',
})
export class PasswordresetComponent {
  resetPasswordForm: any;
  constructor(private fb: FormBuilder,private http: HttpClient,private service:RegisterService ,private router: Router,private toast: NgToastService) {}
  resetPass:IResetPassword ={
    Email:'', 
    oldPassword: '',
    newPassword: ''
  };
  ngOnInit(): void {
    this.resetPasswordForm = this.fb.group({
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]]
    });
  }

  onSubmit() {
    if (this.resetPasswordForm.valid) {
      const newPass=this.resetPasswordForm.value
      console.log(newPass)
      const token:any = localStorage.getItem('Token:');

      if (token) {
        interface DecodedToken extends JwtPayload {
          Email: string;
          Password: string;
        }    
        const decodedToken: DecodedToken = jwtDecode(token);
        const email = decodedToken.Email;
        const password = decodedToken.Password;
        this.resetPass={
          Email:email,
          oldPassword:password,
          newPassword:newPass.password
        }
        this.service.resetPassword(this.resetPass).subscribe(
          data => {
            this.toast.success({
              detail: 'SUCCESS',
              summary: 'Password reset successfully, Login again',
              duration: 2000,
            });
            this.router.navigate(['/login']);
          },
          error => {
            this.toast.error({
              detail: 'SORRY',
              summary: 'Password reset failed. Please try again.',
              duration: 2000,
            });
          }
        );
      } else {
        console.error('No token found in session storage');
      }
    }
  }
  
}
