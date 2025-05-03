import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { response } from '../../models/response';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: AuthService,
    private toaster: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
    this.toaster.success('Test toast works?', 'Toastr Check');

  }

  onSubmit() {
    debugger;
    let formData = this.loginForm.value;
    console.log(formData);

    if (formData != null) {
      this.http.authenticationRequest(formData).subscribe({
        next: (res: response) => {
          if (res.statusCode == 200) {
            this.toaster.success(res.responseMessage, "Success");
          }
          else {
            this.toaster.error(res.responseMessage, "Error");
            setTimeout(() => this.router.navigate(['/login']), 500);
          }
        },
        error: (Error) => {
          console.error('Registration error:', Error);
        }
      })
    }
  //  return;
  }
}
