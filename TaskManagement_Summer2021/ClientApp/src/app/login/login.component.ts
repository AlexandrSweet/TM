import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private baseUrl?: string;
  public invalidLogin?: boolean;
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
      this.router.navigate(['/tasks']);
    },
      err => { this.invalidLogin = true; }
    );
  }

  public isControlInvalid(loginForm: NgForm): boolean {    
    return !loginForm.valid;
    //let control = this.loginForm.getControl(controlName);
    //return !control?.valid;
  }
}
