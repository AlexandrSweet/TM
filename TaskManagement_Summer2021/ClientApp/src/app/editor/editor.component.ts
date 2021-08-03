import { Identifiers } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Task } from '../task';
import { TasksService } from '../tasks.service';
import { Location } from '@angular/common';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent implements OnInit {
  private id: Identifiers = 1;
  private subscription: Subscription | undefined;
  

  @Input() task: Task | any = new Task(1);
  //tasokObservable?: any;

  /*
  taskForm = this.fb.group({
    title: [`${this.task?.title}`, Validators.required],
    description: [`${this.task?.title}`, Validators.required],
    date: [`${this.task?.title}`],
    userId: [`${this.task?.title}`]
  });
  */
  constructor(
    private route: ActivatedRoute,
    private tasksService: TasksService,
    private location: Location,
    private fb: FormBuilder
    
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
      this.tasksService.updateTask(this.task);
      this.location.back();
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
