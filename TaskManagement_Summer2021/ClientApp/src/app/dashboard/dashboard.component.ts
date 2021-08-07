import { DatePipe } from '@angular/common';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Component, NgModule, OnInit } from '@angular/core';
import { Data } from '@angular/router';
import { from } from 'rxjs';
import { JwtInterceptor } from '../jwt-interceptor';
import { Task } from '../task';
import { TasksService } from '../tasks.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
 
  helper = new JwtHelperService();
  private tasks: Task[] = [];
  new: Task[] =[];
  inProgress: Task[] = [];
  checking: Task[] = [];
  done: Task[] = [];
  username: string = '';  

  constructor(private tasksService: TasksService) { this.getCurrentTasks(); }

  ngOnInit(): void {
      
  }

  private getCurrentTasks(): void {
    const userId = this.tasksService.decodedToken['id'];    
    this.tasksService.getUserTasksList(userId).
      subscribe((list: Task[]) => {
        this.tasks = list;
        if (this.tasks.length > 0) {
          this.sort();
        }
      });
    this.username =
      `${this.tasksService.decodedToken['firstName']} ${this.tasksService.decodedToken['lastName']}`;
  }

  public sort() {
    this.new = [];
    this.inProgress = [];
    this.checking = [];
    this.done = [];

    this.tasks.forEach(t => {
      if (t.statusId == 'New')
        this.new.push(t);
      else if (t.statusId == 'InProgress')
        this.inProgress.push(t);
      else if (t.statusId == 'Checking')
        this.checking.push(t);
      else if (t.statusId == 'Done')
        this.done.push(t);
    });
  }
   
  onSelect(selectedTask: Task): void {
    this.tasksService.setCurrentTask(selectedTask.id);
  }

}
