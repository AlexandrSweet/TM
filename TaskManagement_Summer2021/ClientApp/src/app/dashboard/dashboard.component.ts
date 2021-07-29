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
  //task: Task = new Task(1);
  
  
  constructor(private tasksService: TasksService) { }

  ngOnInit(): void {
    this.getCurrentTasks();
  }

  getCurrentTasks(): void {
    this.tasksService.getTasks(0)
      .subscribe(tasks => this.tasks = tasks);
  }

  add(title: string, description: string, date: Date |null): void {//, data: Dates
    const id: Identifiers = 1;
    title = title.trim();
    if (!title) { return; }
    if (!date) { return; }
    this.tasksService.addTask({ id, title, description, date } as Task)
      .subscribe();
  }

  
  onSelect(selectedTask: Task): void {
    if (selectedTask != undefined)
      this.tasksService.setCurrentTask(selectedTask.id);
    //this.task = selectedTask;
  }
  
}
