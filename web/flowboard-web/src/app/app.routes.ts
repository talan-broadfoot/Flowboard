import { Routes } from '@angular/router';
import { Projects } from './projects/projects';
import { ProjectDetail } from './project-detail/project-detail';
import { authGuard } from './auth-guard'
import { Login } from './login/login'

export const routes: Routes = [
  { path: 'projects', component: Projects, canActivate: [authGuard] },
  { path: 'projects/:id', component: ProjectDetail, canActivate: [authGuard] },
  { path: 'login', component: Login },
  { path: "", redirectTo: '/projects', pathMatch: 'full' },
]