import { Identifiers } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Task } from '../task';
import { TasksService } from '../tasks.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent implements OnInit {
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
    this.task = this.tasksService.getCurrentTask();

    if (this.task == null) {
      this.task = this.tasksService.getTask(this.id);
    }
  }

  save(): void {
    if (this.task) {
      this.tasksService.updateTask(this.task)
        .subscribe(() => this.goBack());
    }
  }

  goBack(): void {
    this.location.back();
  }

  delete(): void {
    if (this.task != null)
      this.tasksService.deleteTask(this.task?.id)
        .subscribe(() => this.goBack());
    }
  }

