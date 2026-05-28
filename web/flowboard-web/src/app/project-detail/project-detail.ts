import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../task.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

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

  constructor(private route: ActivatedRoute, private taskService: TaskService, private cdr: ChangeDetectorRef) {}

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
    this.taskService.deleteTask(this.projectId, taskId).subscribe(deleteTask => {
      console.log(deleteTask);
      this.tasks = this.tasks.filter(task => task.id !== taskId);
      this.cdr.detectChanges();
    });
  }
}