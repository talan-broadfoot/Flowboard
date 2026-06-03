import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ProjectService } from '../project.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-projects',
  imports: [FormsModule],
  templateUrl: './projects.html',
  styleUrl: './projects.css',
})
export class Projects implements OnInit {
  projects: any[] = [];
  newProjectName: string = '';
  newProjectStatus: string = '';
  editingProjectID: number | null = null;
  editProjectName: string = '';
  editProjectStatus: string = '';

  constructor(private projectService: ProjectService, private cdr: ChangeDetectorRef, private router: Router) { }

  ngOnInit(): void {
    this.projectService.getProjects().subscribe(data => {
      console.log(data);
      this.projects = data;
      this.cdr.detectChanges();
    })
  }
  addProject() {
    this.projectService.createProject(this.newProjectName, this.newProjectStatus).subscribe(newProject => {
      console.log(newProject)
      this.projects.push(newProject);
      this.cdr.detectChanges();
    })
  }
  deleteProject(projectId: number) {
    if (window.confirm('Are you sure you want to delete this project?')) {
      this.projectService.deleteProject(projectId).subscribe(deleteProject => {
        console.log(deleteProject)
        this.projects = this.projects.filter(project => project.id !== projectId);
        this.cdr.detectChanges();
      })
    }
  }
  navigateToProject(projectId: number) {
    this.router.navigate(['/projects', projectId]);
  }
  startEditingProject(project: any) {
    this.editingProjectID = project.id;
    this.editProjectName = project.name;
    this.editProjectStatus = project.status;
    this.cdr.detectChanges();
  }
  saveProject(projectId: number) {
    this.projectService.updateProject(projectId, { name: this.editProjectName, status: this.editProjectStatus }).subscribe(updatedProject => {
      console.log(updatedProject);
      const index = this.projects.findIndex(p => p.id === projectId);
      if (index !== -1) {
        this.projects[index] = updatedProject;
      }
      this.editingProjectID = null;
      this.cdr.detectChanges();
    });
  }
}
