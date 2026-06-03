import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../task.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-project-detail',
  imports: [CommonModule, FormsModule],
  templateUrl: './project-detail.html',
  styleUrl: './project-detail.css',
})
export class ProjectDetail implements OnInit {
  tasks: any[] = [];
  projectId: number = 0;
  newTaskName: string = '';
  newTaskStatus: string = '';
  newTaskDescription: string = '';
  editingTaskId: number | null = null;
  editTaskName: string = '';
  editTaskStatus: string = '';
  editTaskDescription: string = '';

  constructor(private route: ActivatedRoute, private taskService: TaskService, private cdr: ChangeDetectorRef, private router: Router) { }

  ngOnInit(): void {
    this.projectId = Number(this.route.snapshot.paramMap.get('id'));
    this.taskService.getTasks(this.projectId).subscribe((data: any[]) => {
      console.log(data);
      this.tasks = data;
      this.cdr.detectChanges();
    });
  }
  addTask() {
    this.taskService.createTask(this.projectId, { name: this.newTaskName, status: this.newTaskStatus, description: this.newTaskDescription }).subscribe(newTask => {
      console.log(newTask);
      this.tasks.push(newTask);
      this.cdr.detectChanges();
    });
  }
  deleteTask(taskId: number) {
    if (window.confirm('Are you sure you want to delete this task?')) {
      this.taskService.deleteTask(this.projectId, taskId).subscribe(deleteTask => {
        console.log(deleteTask);
        this.tasks = this.tasks.filter(task => task.id !== taskId);
        this.cdr.detectChanges();
      });
    }
  }
  startEditing(task: any) {
    this.editingTaskId = task.id;
    this.editTaskName = task.name;
    this.editTaskStatus = task.status;
    this.editTaskDescription = task.description;
    this.cdr.detectChanges();
  }
  saveTask(taskId: number) {
    this.taskService.updateTask(this.projectId, { id: taskId, name: this.editTaskName, status: this.editTaskStatus, description: this.editTaskDescription }).subscribe(updatedTask => {
      console.log(updatedTask);
      const index = this.tasks.findIndex(t => t.id === taskId);
      if (index !== -1) {
        this.tasks[index] = updatedTask;
      }
      this.editingTaskId = null;
      this.cdr.detectChanges();
    });
  }
  navigateToProjects() {
    this.router.navigate(['/projects']);
  }
}