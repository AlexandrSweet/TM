import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Task } from './task';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  private url = "/Tasks/";

  constructor(private http: HttpClient) {
  }

  private currentTask?: Task | any;
  

  setCurrentTask(taskId: Identifiers) {
    this.currentTask = this.getTask(taskId);
  }
  getCurrentTask(): Task|null {
    if (this.currentTask != null)
      return this.currentTask;
    else
      return null;
  }


  addTask(task: Task) {
    return this.http.post(this.url + "AddTask", task);
  }

  getTasks(index: number, range: number): Observable<Task[]> {      
    const tasks = this.http.get<any[]>(this.url + "ViewTasks");
    return tasks;
  }

  getTask(id: Identifiers): Observable<Task> {    
    const result = this.http.get<Task>(this.url + id);
    
    return result;
  }

  updateTask(task: Task) {

    return this.http.put(this.url, task);
  }

  deleteTask(id: Identifiers) {
    return this.http.delete(this.url + id);
  }
  
}
