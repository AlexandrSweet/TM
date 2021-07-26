import { Component, Inject, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
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
      email: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    });
  }

  public onSubmit() {
    this.userToRegistration = this.registrationForm.value;
    localStorage.setItem('userToRegistration', JSON.stringify(this.userToRegistration));

    const payload = this.userToRegistration;
    //this.http.post(this.baseUrl + 'user/add-user', payload).subscribe(
    //  result => { console.log("Users controller says: OK") },
    //  error => { console.log("Users controller says: " + error) });
    //this.router.navigate(['/users']);
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
  confirmPassword!: string;
}
