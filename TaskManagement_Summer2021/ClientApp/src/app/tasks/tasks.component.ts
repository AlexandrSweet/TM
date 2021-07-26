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
    this.loadTasks(3);    // загрузка данных при старте компонента
  }
  // получаем данные через сервис
  loadTasks(range: number) :void{
    this.tasksService.getTasks(range)
      .subscribe(tasks => this.tasks = tasks);
  }

  save() {
    if (this.task.id == null) {
      this.tasksService.addTask(this.task)
        .subscribe((data: Task) => this.tasks.push(data));
    } else {
      this.tasksService.updateTask(this.task)
        .subscribe(data => this.loadTasks(3));
    }
    this.cancel();
  }

  editProduct(t: Task) {
    this.task = t;
  }

  cancel() {
    this.task = new Task();
    this.tableMode = true;
  }
  delete(t: Task) {
    if (t.id != null) {
      this.tasksService.deleteTask(t.id)
        .subscribe(data => this.loadTasks(3));
    }
    
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }
}

