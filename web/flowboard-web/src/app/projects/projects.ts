import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../project.service';
import { FormsModule } from '@angular/forms';

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

  constructor(private projectService: ProjectService) {}

  ngOnInit(): void {
    this.projectService.getProjects().subscribe(data => {
      console.log(data);
      this.projects = data;
    })
  }
  addProject() {
    this.projectService.createProject(this.newProjectName, this.newProjectStatus).subscribe(newProject => {
      console.log(newProject)
      this.projects.push(newProject);
    })
  }
}
