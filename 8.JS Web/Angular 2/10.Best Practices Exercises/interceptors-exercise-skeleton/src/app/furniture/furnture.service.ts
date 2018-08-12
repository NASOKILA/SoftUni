import { Injectable } from '@angular/core';
import {
  HttpResponse,
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
  HttpEventType,
  HttpEvent,
  HttpErrorResponse,
  HttpClient
} from '@angular/common/http';

import { Router } from '@angular/router';
import { CreateFurnitureModel } from './models/create-furniture.model';
import { FurnitureModel } from './models/furniture.model';
import { EditFurnitureModel } from './models/edit-furniture.model';

@Injectable()
export class FurntureService {

  constructor(private http: HttpClient) { }

  getAllfurniture(){
    //we parse it to a FurnitureModel array
    let result = this.http.get<FurnitureModel[]>('http://localhost:5000/furniture/all');
    return result; 
  }

  createFurniture(furniture : CreateFurnitureModel){
    return this.http.post('http://localhost:5000/furniture/create', furniture)
  }

  myFurniture(){
    //we can have many furnitures so we parse it into FurnitureModel[]   
    return this.http.get<FurnitureModel[]>('http://localhost:5000/furniture/mine');
  }
  
  deleteFurniture(id : string){
    return this.http.delete('http://localhost:5000/furniture/delete/' + id);
  }

  furnitureDetails(id : string){
    return this.http.get<FurnitureModel>('http://localhost:5000/furniture/details/' + id);    
  }
  
  getFurnitureById(id : string){
    return this.http.get<EditFurnitureModel>('http://localhost:5000/furniture/' + id);    
  }

  updateFurniture(furniture : EditFurnitureModel){
    return this.http.put('http://localhost:5000/furniture/edit/' + furniture.id, furniture)
  }

}
