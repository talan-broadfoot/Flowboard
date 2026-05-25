import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ProjectService } from '../project.service';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-projects',
  imports: [FormsModule,RouterLink],
  templateUrl: './projects.html',
  styleUrl: './projects.css',
})
export class Projects implements OnInit {
  projects: any[] = [];
  newProjectName: string = '';
  newProjectStatus: string = '';

  constructor(private projectService: ProjectService, private cdr: ChangeDetectorRef){}

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
    this.projectService.deleteProject(projectId).subscribe(deleteProject => {
      console.log(deleteProject)
      this.projects = this.projects.filter(project => project.id !== projectId);
      this.cdr.detectChanges();
    })
  }
}
