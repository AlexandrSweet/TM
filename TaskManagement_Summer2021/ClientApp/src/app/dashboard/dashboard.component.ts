import { DatePipe } from '@angular/common';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Component, NgModule, OnInit } from '@angular/core';
import { Data } from '@angular/router';
import { from } from 'rxjs';
import { JwtInterceptor } from '../jwt-interceptor';
import { Task } from '../task';
import { TasksService } from '../tasks.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  tasks: Task[] = [];

  constructor(private tasksService: TasksService) { }

  ngOnInit(): void {
    this.getCurrentTasks();
  }

  private userId: Identifiers =  '27ae29fa-7ecc-44fe-ef56-08d95021f963';
  private getCurrentTasks(): void {
    this.tasksService.getUserTasksList(this.userId).
      subscribe((list: any) => { this.tasks = list });;
      
      
  }
  


  onSelect(selectedTask: Task): void {
    this.tasksService.setCurrentTask(selectedTask.id);
  }

}
