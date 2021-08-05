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
  tasks: Task[] = [];
  username: string = '';
  private decodedToken = this.helper.decodeToken(localStorage.jwt);

  constructor(private tasksService: TasksService) { }

  ngOnInit(): void {
    this.getCurrentTasks();
  }

  private getCurrentTasks(): void {
    const userId = this.decodedToken['id'];
    this.username =
      `${this.decodedToken['firstName']} ${this.decodedToken['lastName']}`;
    this.tasksService.getUserTasksList(userId).
      subscribe((list: any) => { this.tasks = list });    
  }
  
  onSelect(selectedTask: Task): void {
    this.tasksService.setCurrentTask(selectedTask.id);
  }

}
