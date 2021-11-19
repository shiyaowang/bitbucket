import { Injectable } from '@angular/core';
import { NameDetail } from './name-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class NameDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:37107/api/NameDetail"
  formData:NameDetail = new NameDetail();

  list: NameDetail[] = [];

  

  postNameDetail(){
    return this.http.post(this.baseURL, this.formData);
  }

  // refreshList(){
  //   this.http.get(this.baseURL)
  //     .toPromise()
  //     .then(res => this.list = res as NameDetail[]);    
  // }
}
