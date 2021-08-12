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
  public isValid: boolean = true;
  constructor(
    private tasksService: TasksService,
    private http: HttpClient,    
    private location: Location
  ) {   
  }

  ngOnInit(): void {
   // this.setUsers();
     this.getUsers();
    //this.users = this.tasksService.getUsers();
  }
  


  add(title: string, description: string, date: Date | null, userId:any): void {//, data: Dates
    const id: Identifiers = 1;
    title = title.trim();    
    if (!title) { this.isValid = false; return console.warn('enter title'); }
    if (!title) { this.isValid = false; return console.warn('enter description'); }
    if (!date) { this.isValid = false; return console.warn('enter date'); }
    this.tasksService.addTask({ title, description, date, userId } as Task)
      .subscribe();
    this.goBack();
  }

  goBack(): void {
    
    this.location.back();
  }

  private getUsers() {
    this.tasksService.getUsers()
      .subscribe(result => { this.users = result });
  }
  public setValid() {
    this.isValid = true;
  }
}
