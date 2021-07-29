import { Component, OnInit, Input } from '@angular/core';
import { Task } from '../task'
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { TasksService } from '../tasks.service';
import { Identifiers } from '@angular/compiler/src/render3/r3_identifiers';
import { __param } from 'tslib';

@Component({
  selector: 'app-task-detail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.scss']
})
export class TaskDetailComponent implements OnInit {

  @Input() task: Task| null = new Task(1);

  constructor(
    private route: ActivatedRoute,
    private tasksService: TasksService,
    private location: Location
  ) {
    const id = this.tasksService.getCurrentTask()?.id;
    if (id != undefined)
    this.task = new Task(id);
  }
  //const url = `${this.heroesUrl}/${id}`;
  ngOnInit(): void {
    //const id = this.tasksService.getCurrentTask()?.id;
    //if (id != undefined)
    let url ;
    let routeID = this.route.
      queryParams.subscribe(
        params => url = params.id
      );
    
    this.task = this.tasksService.getCurrentTask();
    if (this.task == null) {
      this.task = this.tasksService.getTask(url);
    }
  }    

  /*getTask(): void {
    const id = this.tasksService.getCurrentTask()?.id;
    if (id != undefined) {
      //this.tasksService.getTask(id);
      this.task = new Task(id);
      this.task = this.tasksService.getCurrentTask();
    }          
  }*/

  save(): void {
    if (this.task) {
      this.tasksService.updateTask(this.task)
        .subscribe(() => this.goBack());
    }
  }

  goBack(): void {
    this.location.back();
  }
      
}


