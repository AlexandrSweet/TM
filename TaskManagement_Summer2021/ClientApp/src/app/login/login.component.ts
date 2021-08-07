import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private baseUrl?: string;
  public invalidLogin?: boolean;
  public user!: User;
  public roleNow!: string;
  //public loginForm!: NgForm;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
  }
  registration() {
    this.router.navigate(['/registration']);
  }

  login(form: NgForm) {
    const payload = form.value;
    this.http.post(this.baseUrl + 'auth/login', payload).subscribe(result => {
      const token = (<any>result).token;
      localStorage.setItem('jwt', token);
      this.invalidLogin = false;
      this.roleNow = (<any>result).roleUser;
      localStorage.setItem('loginUserRole', this.roleNow);
      this.router.navigate(['/tasks']);
    },
      err => { this.invalidLogin = true; }
    );
  }

  public isControlInvalid(loginForm: NgForm): boolean {    
    return !loginForm.valid;   
  }
}
