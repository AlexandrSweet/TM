import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Task } from './task';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { Observable } from 'rxjs';
import { __param } from 'tslib';
import { DatePipe } from '@angular/common';
import { User } from './models/User';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class TasksService {
  helper = new JwtHelperService();
  private url = "Tasks/";
  private currentTaskId: Identifiers | string | any;
  private baseUrl: string;
  public decodedToken = this.helper.decodeToken(localStorage.jwt);

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  setCurrentTask(taskId: Identifiers) {
    if (taskId === this.currentTaskId) { return; }
    this.currentTaskId = taskId;
  }

  
  getCurrentTask() {    
    if (!this.currentTaskId) { return null; }
    else
      return this.getTask(this.currentTaskId);
  }
  

  addTask(task: Task): Observable<string> {
    return this.http.post<string>(this.baseUrl + `${this.url}AddTask`, task);
  }
  
  getTasksList(): Observable<Task[]> {  
    const tasks = this.http.get<Task[]>(this.baseUrl + `${this.url}ViewTasks`);
    return tasks;
  }

  getUserTasksList(userId: Identifiers | string): Observable<Task[]> {
    const tasks = this.http.get<Task[]>(this.baseUrl + `${this.url}UserTasks/${userId}` )      
    return tasks;
  }  

  getTask(id: Identifiers | string) {
    return this.http.get<Task>(this.baseUrl + `${this.url}${id}`)
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  updateTask(task: Task): Observable<any> {
    return this.http.put(this.baseUrl + `${this.url}${task.id}/edit`, task);
  }

  deleteTask(id: Identifiers) {
    return this.http.delete(this.baseUrl + `${this.url}${id}`);
  }

  getUsers() {
    return this.http.get<User[]>(this.baseUrl + 'users/get-users');
  }
}

