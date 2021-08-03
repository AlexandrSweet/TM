import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Task } from './task';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Observable } from 'rxjs';
import { __param } from 'tslib';
import { DatePipe } from '@angular/common';


@Injectable({
  providedIn: 'root'
})
export class TasksService {
  private url = "Tasks/";
  private currentTaskId: Identifiers | string | any;
  private baseUrl!: string;
  

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  setCurrentTask(taskId: Identifiers) {
    if (taskId === this.currentTaskId) { return; }
    this.currentTaskId = taskId;
  }

  getCurrentTask(): Task | null {
    if (!this.currentTaskId) { return null; }
    else
      return this.getTask(this.currentTaskId);
  }

  addTask(task: Task) {
    return this.http.post(this.baseUrl + `${this.url}AddTask`, task);
  }
  
  getTasksList(index: number): Observable<Task[]> { //returns an Observable<Task[]>    
    const tasks = this.http.get<Task[]>(this.baseUrl + `${this.url}ViewTasks`);
    return tasks;
  }

  getTask(id: Identifiers | string): Task {
    let taskTemp = new Task(id);
    let observable = this.http.get<Task>(this.baseUrl + `${this.url}${id}`)
      .subscribe(task => {
        taskTemp.title = task.title,
          taskTemp.description = task.description,
          taskTemp.date = task.date,
          taskTemp.statusId = task.statusId,
          taskTemp.userId = task.userId
      });

    return taskTemp;
  }

  get task() {
    return this.http.get(this.baseUrl + `${this.url}${this.currentTaskId}`)
  }

  updateTask(task: Task): Observable<any> {
    return this.http.put(this.baseUrl + `${this.url}${task.id}/edit`, task);
  }

  deleteTask(id: Identifiers) {
    return this.http.delete(this.baseUrl + `${this.url}${id}`);
  }

}

