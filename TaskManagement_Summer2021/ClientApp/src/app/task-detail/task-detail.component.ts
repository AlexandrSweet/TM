import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../task'
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { TasksService } from '../tasks.service';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { __param } from 'tslib';
import { Subscription } from 'rxjs';
import { query } from '@angular/animations';

@Component({
  selector: 'app-task-detail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.scss']
})
export class TaskDetailComponent implements OnInit {
  
  private id: Identifiers = 1;
  private subscription: Subscription | undefined;

  @Input() task: Task | null = new Task(1);

  constructor(
    private route: ActivatedRoute,
    private tasksService: TasksService,
    private location: Location
  ) {
    this.subscription = route.params.subscribe(params => this.id = params['id']);
    
  }

  ngOnInit(): void {
    this.tasksService.getCurrentTask()?.
      subscribe(task => this.task = task);

    if (!this.task) {
      this.tasksService.getTask(this.id)
        .subscribe(task => this.task = task);
    }    
  }
  save(): void {
    if (this.task) {
      this.tasksService.updateTask(this.task);
      this.location.back();
    }
  }

  goBack(): void {
    this.location.back();
  }

}


