import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../task.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-project-detail',
  imports: [CommonModule],
  templateUrl: './project-detail.html',
  styleUrl: './project-detail.css',
})
export class ProjectDetail implements OnInit {
  tasks: any[] = [];
  projectId: number = 0;

  constructor(private route: ActivatedRoute, private taskService: TaskService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.projectId = Number(this.route.snapshot.paramMap.get('id'));
    this.taskService.getTasks(this.projectId).subscribe((data: any[]) => {
      console.log(data);
      this.tasks = data;
      this.cdr.detectChanges();
    });
  }
}