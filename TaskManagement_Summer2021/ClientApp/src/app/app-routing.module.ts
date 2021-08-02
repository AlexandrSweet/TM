import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { TasksComponent } from './tasks/tasks.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TaskDetailComponent } from './task-detail/task-detail.component';
import { RegistrationComponent } from './registration/registration.component';
import { UserRoleEditComponent } from './user-role-edit/user-role-edit.component';

const routes: Routes = [
  //{ path: '', redirectTo: "/dashboard", pathMatch: 'full' },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'tasks', component: TasksComponent },
  { path: 'detail/:id', component: TaskDetailComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },  
 // { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
 // { path: 'task - list', component: TaskListComponent }];
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
