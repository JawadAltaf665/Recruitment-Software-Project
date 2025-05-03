import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { response } from '../../models/response';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  signupForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private toaster: ToastrService,
    private http: AuthService) { }
  ngOnInit(): void{
    this.signupForm = this.fb.group({
      id: [0],
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      role: ['', Validators.required]
    });
  }

  onSubmit() {
    debugger;
    const formData = {
      ...this.signupForm.value,
      createdAt: new Date().toISOString()
    };
    console.log(formData);
    if (formData.id == 0) {
      this.http.registrationRequest(formData).subscribe({
        next: (res: response) => {
          if (res.statusCode == 200) {
            this.toaster.success(res.responseMessage, "Success");
            this.router.navigate(['/login']);
          }
          else {
            this.toaster.error(res.responseMessage, "Error");
            this.router.navigate(['/register']);
          }
        },
        error: (Error) => {
          console.error('Registration error:', Error);
        }
      })
    }
    else {
      this.http.registrationRequest(formData).subscribe({
        next: (res: response) => {
          if (res.statusCode == 200) {
            this.toaster.success(res.responseMessage, "Success");
            this.router.navigate(['/login']);
          }
          else {
            this.toaster.error(res.responseMessage, "Error");
            this.router.navigate(['/register']);
          }
        },
        error: (Error) => {
          console.error('Registration error:', Error);
        }
      })
    }
    

  }
}
