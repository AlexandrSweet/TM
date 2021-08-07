import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { TasksComponent } from './tasks/tasks.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TaskDetailComponent } from './task-detail/task-detail.component';
import { RegistrationComponent } from './registration/registration.component';
import { EditorComponent } from './editor/editor.component';
import { NewTaskComponent } from './new-task/new-task.component';
import { UserRoleEditComponent } from './user-role-edit/user-role-edit.component';
import { RoleGuardService } from './role-guard.service';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'tasks', component: TasksComponent, canActivate: [RoleGuardService] },
  { path: 'new-task', component: NewTaskComponent, canActivate: [RoleGuardService] },
  { path: 'detail/:id', component: TaskDetailComponent },
  { path: 'edit/:id', component: EditorComponent, canActivate: [RoleGuardService] },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },  
  { path: 'registration', component: RegistrationComponent },
  { path: 'user-role-list', component: UserRoleEditComponent, canActivate: [RoleGuardService] },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
