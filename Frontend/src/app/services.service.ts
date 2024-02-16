import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  
 readonly apiurl = "http://localhost:53563/api";
  constructor(private http:HttpClient) { }
  

  getDataStaff () :Observable<any[]>
  {
    return this.http.get<any>(this.apiurl+'/Staff');
  }
  AddDataStaff (val:any) : Observable<any>
  {
    return this.http.post<any>(this.apiurl+'/Staff',val)
  }
  UpdateDataStaff (val:any) : Observable<any>
  {
    return this.http.put<any>(this.apiurl+'/Staff',val)
  }
  DeleteDataStaff (val:any) : Observable<any>
  {
    return this.http.delete<any>(this.apiurl+'/Staff/'+val)
  }
}
