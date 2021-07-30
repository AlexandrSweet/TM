import { Identifiers } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Task } from '../task';
import { TasksService } from '../tasks.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.scss']
})
export class NewTaskComponent implements OnInit {

  constructor(private tasksService: TasksService,
    private location: Location) { }

  ngOnInit(): void {
    
  }
  

  add(title: string, description: string, date: Date | null): void {//, data: Dates
    const id: Identifiers = 1;
    title = title.trim();
    if (!title) { return; }
    if (!date) { return; }
    this.tasksService.addTask({ id, title, description, date } as Task)
      .subscribe();
    this.goBack();
  }

  goBack(): void {
    this.location.back();
  }
}
