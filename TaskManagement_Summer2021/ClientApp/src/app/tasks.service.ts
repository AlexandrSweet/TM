import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Task } from './task';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  private url = "/Tasks";

  constructor(private http: HttpClient) {
  }

  addTask(task: Task) {
    return this.http.post(this.url + "AddTask", task);
  }

  getTasks(range: number): Observable<Task[]> {
    const tasks = this.http.get <Task[]>(this.url + "ViewTasks");
    return tasks;
  }

  updateTask(task: Task) {

    return this.http.put(this.url, task);
  }

  deleteTask(id: Identifiers) {
    return this.http.delete(this.url + '/' + id);
  }
  
}
