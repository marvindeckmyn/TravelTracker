import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VisitService {
  private apiUrl = 'https://localhost:7141/api/Visits';

  constructor(private http: HttpClient) { }

  getVisits(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addVisit(visit: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, visit);
  }

  deleteVisit(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
