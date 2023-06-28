import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  constructor(private _httpClient: HttpClient) { }

  Search(employeeId:string):Observable<any>{
    if(employeeId == "" || employeeId == undefined){
      return this.SearchAll();
    }
    else{
      return this.SearchById(employeeId);
    }
  }

  private SearchAll():Observable<any>{
    return this._httpClient.get(environment.SERVICE_URL + 'Employee');
  }

  private SearchById(employeeId:string):Observable<any>{
    return this._httpClient.get(environment.SERVICE_URL + 'Employee/'+ employeeId);
  }
}
