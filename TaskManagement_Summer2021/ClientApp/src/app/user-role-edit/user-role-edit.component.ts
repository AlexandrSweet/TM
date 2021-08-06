import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { User } from '../models/User';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';
import { Identifiers } from '@angular/compiler';


@Component({
  selector: 'app-user-role-edit',
  templateUrl: './user-role-edit.component.html',
  styleUrls: ['./user-role-edit.component.scss']
})
export class UserRoleEditComponent implements OnInit {

  public Users!: Array<User>;
  public userToEditRoleForm!: FormGroup;
  public userToEditRole!: User;
  public user!: User;
  private baseUrl: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.baseUrl = baseUrl;
    http.get<Array<User>>(baseUrl + 'users/get-users').subscribe(
      result => { this.Users = result; },
      error => { console.log("Users controller says: " + error) });
  }

  ngOnInit(): void {
    this.buildForm();
  }

  public onEdit(userToEditRoleForm: any, user: any) {
    this.userToEditRole = this.userToEditRoleForm.value;
    if (this.userToEditRole.roleId !== "") {
      user.roleId = this.userToEditRole.roleId;
    }
    const payload = user;
    this.http.put(this.baseUrl + 'Users/edit-user', payload).subscribe(
      result => { console.log("User controller says: OK") },
      error => { console.log("User controller says: " + error) });
    this.userToEditRoleForm.reset();
    window.location.reload();
  }
  private buildForm() {
    this.userToEditRoleForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      roleId: ['', Validators.required]
    });
  }
}

