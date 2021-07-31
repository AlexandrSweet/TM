import { Component, Inject, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { FormBuilder, FormGroup, Validators, ValidationErrors, AbstractControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../models/User';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  public registrationForm!: FormGroup;
  public userToRegistration!: UserToRegistration;
  private baseUrl: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.buildForm();
    this.baseUrl = baseUrl;   

  }

  ngOnInit(): void {
  }

  private buildForm() {
    this.registrationForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      passwordConfirm: ['', Validators.required]
    },{
      validator: MustMatch('password', 'passwordConfirm')}
    );
  }

  public onSubmit() { 
    this.userToRegistration = this.registrationForm.value;
    localStorage.setItem('userToRegistration', JSON.stringify(this.userToRegistration));

    const payload = this.userToRegistration;
    this.http.post(this.baseUrl + 'account', payload).subscribe(
      result => {
        console.log("Account controller says: OK");
      },
      error => { console.error("Account controller says: " + error) });
    this.router.navigate(['/login']);
  }

  public isControlInvalid(controlName: string): boolean {
    let control = this.registrationForm.get(controlName);
    return !control?.valid;
  }
}
export class UserToRegistration {
  firstName!: string;
  lastName!: string;
  email!: string;
  password!: string;
  passwordConfirm!: string;
}

export function MustMatch(controlName: string, matchingControlName: string) {
  return (formGroup: FormGroup) => {
    const control = formGroup.controls[controlName];
    const matchingControl = formGroup.controls[matchingControlName];

    if (matchingControl.errors && !matchingControl.errors.mustMatch) {
      // return if another validator has already found an error on the matchingControl
      return;
    }

    // set error on matchingControl if validation fails
    if (control.value !== matchingControl.value) {
      matchingControl.setErrors({ mustMatch: true });
    } else {
      matchingControl.setErrors(null);
    }
  }
}
