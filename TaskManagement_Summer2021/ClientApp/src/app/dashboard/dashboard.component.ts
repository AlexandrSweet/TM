import { DatePipe } from '@angular/common';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Component, NgModule, OnInit } from '@angular/core';
import { Data } from '@angular/router';
import { from } from 'rxjs';
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

  private getCurrentTasks(): void {
    this.tasksService.getTasksList(0)
      .subscribe(tasks => this.tasks = tasks);
  }
  


  onSelect(selectedTask: Task): void {
    this.tasksService.setCurrentTask(selectedTask.id);
  }

}
