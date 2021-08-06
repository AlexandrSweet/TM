import { Identifiers } from '@angular/compiler';
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { from, Subscription, Subject } from 'rxjs';
import { Task } from '../task';
import { TasksService } from '../tasks.service';
import { DataTableDirective } from 'angular-datatables';
import { TaskListModel } from '../models/TaskListModel';
import { forEach } from 'jszip';



@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.scss'],
  providers: [TasksService]
})

export class TasksComponent implements OnInit, OnDestroy {
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  @ViewChild(DataTableDirective, { static: false })
  datatableElement: any = DataTableDirective;
  min: any = 0;
  max: any = 0;

  tasks: TaskListModel []= [];  

  constructor(private tasksService: TasksService) { }

  ngOnInit() {
    this.loadTasks();
    $.fn.DataTable({
      retrieve: true,
      paging: false,
      destroy: true,
      searching: false

    });
    
    this.dtOptions = {
      // Declare the use of the extension in the dom parameter
      dom: 'Bfrtip',

    };
  }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
    $.fn.dataTable.ext.search.pop();
  }

  loadTasks(): void {
    this.tasksService.getTasksList()
      .subscribe((response: any) => {
        this.tasks = response;        
        // initiate our data table
        this.dtTrigger.next();
      });
    
  }
  
  
  
  onSelect(selectedTask: Task): void {
    this.tasksService.setCurrentTask(selectedTask.id);
  }

  filterById(): void {
    this.datatableElement.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.draw();
    });
  }
}

