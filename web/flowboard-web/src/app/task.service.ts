import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private apiUrl = 'http://localhost:5087/api';

  constructor(private http: HttpClient) {}

  getTasks(projectId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/project/${projectId}/tasks`);
  }

  createTask(projectId: number, task: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/project/${projectId}/tasks`, task);
  }

  updateTask(projectId: number, task: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/project/${projectId}/tasks/${task.id}`, task);
  }

  deleteTask(projectId: number, id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/project/${projectId}/tasks/${id}`);
  }
}
