import { Component, OnInit } from '@angular/core';
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
    this.tasksService.getTasks(0, 4)
      .subscribe(tasks => this.tasks = tasks);
  }

  
  onSelect(selectedTask: Task): void {
    if (selectedTask != undefined)
      this.tasksService.setCurrentTask(selectedTask.id);
    //this.task = selectedTask;
  }
  
}
