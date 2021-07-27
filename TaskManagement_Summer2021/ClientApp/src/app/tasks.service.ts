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

  addTask(task: Task) {
    return this.http.post(this.url + "AddTask", task);
  }

  getTasks(index: number, range: number): Observable<Task[]> {      
    const tasks = this.http.get<any[]>(this.url + "ViewTasks");
    return tasks;
  }

  getTask(id: number): Observable<Task> {
    // For now, assume that a hero with the specified `id` always exists.
    // Error handling will be added in the next step of the tutorial.
    const task = this.http.get<Task>(this.url + "ViewTasks"+id.toString);
    //const hero = HEROES.find(h => h.id === id)!;
    //this.messageService.add(`HeroService: fetched hero id=${id}`);
    return task;
  }

  updateTask(task: Task) {

    return this.http.put(this.url, task);
  }

  deleteTask(id: Identifiers) {
    return this.http.delete(this.url + '/' + id);
  }
  
}
