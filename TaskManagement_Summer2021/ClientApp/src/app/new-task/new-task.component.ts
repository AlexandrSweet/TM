import { Identifiers } from '@angular/compiler';
import { Component, Inject, OnInit } from '@angular/core';
import { Task } from '../task';
import { TasksService } from '../tasks.service';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { forEach } from 'jszip';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.scss']
})
export class NewTaskComponent implements OnInit {
  public users: User[] = [];
  private baseUrl!: string;
  constructor(
    private tasksService: TasksService,
    private http: HttpClient, @Inject ('BASE_URL') baseUrl: string,
    private location: Location
  ) {
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
   // this.setUsers();
     this.getUsers();
    //this.users = this.tasksService.getUsers();
  }
  


  add(title: string, description: string, date: Date | null, userId:any): void {//, data: Dates
    const id: Identifiers = 1;
    title = title.trim();
    if (!title) { return; }
    if (!date) { return; }
    this.tasksService.addTask({ title, description, date, userId } as Task)
      .subscribe();
    this.goBack();
  }

  goBack(): void {
    
    this.location.back();
  }

  private getUsers() {
    this.http.get<User[]>(this.baseUrl + 'users/get-users')
      .subscribe(
        result => { this.users = result });
  }
   
}
