import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../task'
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { TasksService } from '../tasks.service';

@Component({
  selector: 'app-task-detail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.scss']
})
export class TaskDetailComponent implements OnInit {


  @Input() task?: Task;

  constructor(
    private route: ActivatedRoute,
    private tasksService: TasksService,
    private location: Location
  ) { }

  ngOnInit(): void {
  }

  getTask(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.tasksService.getTask(id)
      .subscribe(task => this.task = task);
  }

}
