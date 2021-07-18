import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'login', component: LoginComponent }
  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
