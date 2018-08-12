import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class HttpClientService {
  constructor(
    private http: HttpClient
  ) { }

  public get<T>(url : string) {
    return this.http.get<T>(url);
  }
  
  public post<T>(url : string, body : any) {
    return this.http.post<T>(url, body)
  }

  public put<T>(url : string, body : any) {
    return this.http.put<T>(url, body);
  }
  
  public delete<T>(url : string, id : number) {
    return this.http.delete<T>(`${url}/${id}`);
  }
}