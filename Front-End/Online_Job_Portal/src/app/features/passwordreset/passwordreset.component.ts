import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-passwordreset',
  templateUrl: './passwordreset.component.html',
  styleUrl: './passwordreset.component.css',
})
export class PasswordresetComponent {
  resetPasswordForm: any;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.resetPasswordForm = this.fb.group({
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]]
    });
  }

  onSubmit() {
    if (this.resetPasswordForm.valid) {
      // Your form submission logic goes here
      console.log('Form submitted with values:', this.resetPasswordForm.value);
    }
  }
  
}
