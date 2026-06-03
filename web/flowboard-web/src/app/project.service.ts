import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ProjectService {
    private apiUrl = 'http://localhost:5087/api/project';

    constructor(private http: HttpClient) {}

    getProjects(): Observable<any[]> {
        return this.http.get<any[]>(this.apiUrl);
    }
    createProject(name: string, status: string): Observable<any> {
        return this.http.post<any>(this.apiUrl, {name: name, status: status}) 
    }
    updateProject(projectId: number, projectData: any): Observable<any> {
        return this.http.put<any>(`${this.apiUrl}/${projectId}`, projectData)
    }
    deleteProject(projectId: number): Observable<any> {
        return this.http.delete<any>(`${this.apiUrl}/${projectId}`)
    }
}