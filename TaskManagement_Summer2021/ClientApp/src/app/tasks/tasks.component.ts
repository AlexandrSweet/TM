import { Identifiers } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { Task } from '../task';
import { TasksService } from '../tasks.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.scss'],
  providers: [TasksService]
})
export class TasksComponent implements OnInit {
  task: Task = new Task(1);
  tasks: Task[] = [];  

  constructor(private tasksService: TasksService) { }

  ngOnInit() {
    this.loadTasks(0);
  }

  
  loadTasks(index:number) :void{
    this.tasksService.getTasksList(index)
      .subscribe(tasks => this.tasks = tasks);
  }
    
  editTask(task: Task) {//is this useless?
    this.tasksService.updateTask(task);
  }   

  delete(task: Task):void {
    if (task.id != null) {
      this.tasksService.deleteTask(task.id)
        .subscribe(data => this.loadTasks(0));
    }    
  }

  onSelect(selectedTask: Task): void {
    this.tasksService.setCurrentTask(selectedTask.id);
  }
}

