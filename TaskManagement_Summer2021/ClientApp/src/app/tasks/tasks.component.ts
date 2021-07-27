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
  task: Task = new Task();
  tasks: Task[] = [];
  tableMode: boolean = true;

  constructor(private tasksService: TasksService) { }

  ngOnInit() {
    this.loadTasks(0,5);    // загрузка данных при старте компонента
  }

  // получаем данные через сервис
  loadTasks(index:number,range: number) :void{
    this.tasksService.getTasks(index, range)
      .subscribe(tasks => this.tasks = tasks);
  }

  save() {
    if (this.task.id == null) {
      this.tasksService.addTask(this.task)
        .subscribe((data: Task) => this.tasks.push(data));
    } else {
      this.tasksService.updateTask(this.task)
        .subscribe(data => this.loadTasks(0,5));
    }
    this.cancel();
  }

  
  editTask(t: Task) {
    this.task = t;    
  }

  cancel(): boolean {
    this.task = new Task();
    this.tableMode = true;
    return true;
  }
  delete(t: Task) {
    if (t.id != null) {
      this.tasksService.deleteTask(t.id)
        .subscribe(data => this.loadTasks(0,3));
    }
    
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }
}

