import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Task } from './task';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Observable } from 'rxjs';
import { __param } from 'tslib';


@Injectable({
  providedIn: 'root'
})
export class TasksService {
  private url = "/Tasks/";
  private taskUrl = '/Tasks/';
  cookieValue: string = "";

  private currentTask?: Observable<Task> | any;


  setCurrentTask(taskId: Identifiers) {
    this.currentTask = this.getTask(taskId);
    //this.cookieService.set('currentTaskId', taskId.toString());
  }
  getCurrentTask(): Task | null {
    if (this.currentTask != null)
      return this.currentTask;
    //this.cookieValue = this.cookieService.get('currentTaskId');
    //if (this.cookieValue != null)
    //  return this.getTask(this.cookieValue);
    else
      return null;
  }

  constructor(private http: HttpClient) { }  


  addTask(task: Task) {
    return this.http.post(this.url + "AddTask", task);
  }

  getTasks(index: number): Observable<Task[]> { //returns an Observable<Task[]>    
    const tasks = this.http.get<Task[]>(this.url + "ViewTasks");
    return tasks;
  }

  getTask(id: Identifiers | string): Task { //returns currentTask : Task
    this.http.get<Task>(this.url + id)
      .subscribe(task => this.currentTask = task);
    return this.currentTask;
  }

  updateTask(task: Task): Observable<any> {
    return this.http.put(this.url + task.id + '/edit', task);
  }

  deleteTask(id: Identifiers) {
    return this.http.delete(this.url + id);
  }
  
}
