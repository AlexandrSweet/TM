import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { User } from '../models/User';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})
export class TaskListComponent implements OnInit {

  public Users!: Array<User>;
  public userToEditRoleForm!: FormGroup;
  public userToEditRole!: User;
  public user!: User;  
  public baseUrl!: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    http.get<Array<User>>(baseUrl + 'users/get-users').subscribe(
      result => { this.Users = result; },
      error => { console.log("Users controller says: " + error) });
  }

  ngOnInit(): void {
    this.buildForm();
  }
  public onEdit(userToEditRoleForm:any, user:any) {
    this.userToEditRole = this.userToEditRoleForm.value;
    this.user = user;
    if (this.userToEditRole.roleId !== "") {
      this.user.roleId = this.userToEditRole.roleId;
    }
    const payload = this.user;
    this.http.put(this.baseUrl + 'user/edit-user', payload).subscribe(
      result => { console.log("User controller says: OK") },
      error => { console.log("User controller says: " + error) });
    /*this.router.navigate(['/tasks']);*/
    this.userToEditRoleForm.reset();    
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
