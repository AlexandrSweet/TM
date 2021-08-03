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
  private statusIdValue: string[] = ['New', 'In progress', 'Checking', 'Done'];
  public statusValue: string | undefined;
  public statusId: number[] = [0, 1, 2, 3];
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

    if (!this.task) {
      this.task = this.tasksService.getTask(this.id);
      if (this.task?.statusId) {
        this.statusValue = this.statusIdValue[this.task.statusId];
      }
    }
    
  }

  goBack(): void {
    this.location.back();
  }

}


