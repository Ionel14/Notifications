import { Injectable } from '@angular/core';
import { Category } from '../category';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private baseURL="https://localhost:7066/Categories "
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  
  serviceCall() {
    console.log("Service was called");
   }
   
   constructor(private httpClient:HttpClient) {     
  }

  getCategories(): Observable<Category[]>
  {
    return this.httpClient.get<Category[]>(this.baseURL);
  }
}
