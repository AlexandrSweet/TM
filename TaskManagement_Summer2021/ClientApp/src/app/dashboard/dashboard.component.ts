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


  constructor(private taskService: TasksService) { }

  ngOnInit(): void {
    this.getCurrentTasks();
  }

  getCurrentTasks(): void {
    this.taskService.getTasks(0, 4)
      .subscribe(tasks => this.tasks = tasks);
  }

}
