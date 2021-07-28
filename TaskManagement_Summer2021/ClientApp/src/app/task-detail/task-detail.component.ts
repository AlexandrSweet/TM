import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../task'
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { TasksService } from '../tasks.service';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';

@Component({
  selector: 'app-task-detail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.scss']
})
export class TaskDetailComponent implements OnInit {

  @Input() task: Task | null = new Task(1);

  constructor(
    private route: ActivatedRoute,
    private tasksService: TasksService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getTask();
  }    

  getTask(): void {
    const id = this.tasksService.getCurrentTask()?.id;
    if (id != undefined) {
      //this.tasksService.getTask(id);
      this.task = this.tasksService.getCurrentTask();
    }          
  }

  goBack(): void {
    this.location.back();
  }
      
}


