import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { JwtInterceptor } from './jwt-interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { getBaseUrl } from '../main';
import { RegistrationComponent } from './registration/registration.component';
import { TasksComponent } from './tasks/tasks.component';
import { TaskDetailComponent } from './task-detail/task-detail.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DatepickerComponent } from './datepicker/datepicker.component';
import { MaterialModule } from './material/material.module';
import { EditorComponent } from './editor/editor.component';
import { NewTaskComponent } from './new-task/new-task.component';
import { DataTablesModule } from 'angular-datatables';
import { CookieService } from 'ngx-cookie-service';
import { UserRoleEditComponent } from './user-role-edit/user-role-edit.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegistrationComponent,   
    HomeComponent,
    TasksComponent, 
    TaskDetailComponent,
    DashboardComponent,
    DatepickerComponent,
    EditorComponent,
    NewTaskComponent,       
    UserRoleEditComponent
  ],
    imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    DataTablesModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    //{ provide: 'BASE_URL', useValue: "https://task-management.azurewebsites.net/", multi: true }
    { provide: 'BASE_URL', useValue: "https://localhost:44379/", multi: true }
  ],
  //bootstrap: [DatepickerComponent]
  bootstrap: [AppComponent]
})
export class AppModule { }
