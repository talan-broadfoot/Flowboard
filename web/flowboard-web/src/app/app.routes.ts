import { Routes } from '@angular/router';
import { Projects } from './projects/projects';
import { ProjectDetail } from './project-detail/project-detail';

export const routes: Routes = [
  { path: 'projects', component: Projects },
  { path: 'projects/:id', component: ProjectDetail },
  { path: "", redirectTo: '/projects', pathMatch: 'full' }
];