import { Component, OnInit } from '@angular/core';
import { FurntureService } from '../furnture.service';
import { FurnitureModel } from '../models/furniture.model';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../../authentication/auth.service';

@Component({
  selector: 'app-my-furniture',
  templateUrl: './my-furniture.component.html',
  styleUrls: ['./my-furniture.component.css']
})

export class MyFurnitureComponent implements OnInit {

  furnitures : Observable<FurnitureModel[]>;
  
  pageSize : number = 3;
  currentPage : number = 1;
  isAdmin : Boolean;

  constructor(
    private furnitureService : FurntureService,
    private authService : AuthService,
    private router : Router) { }

  ngOnInit() {  

    this.isAdmin = this.authService.isAdmin();

    //if we wnt to use it like this we need to add   " | async" in the *ngFor() 
    this.furnitures = this.furnitureService.myFurniture();
  }

  delete(id : string){
    this.furnitureService.deleteFurniture(id)
      .subscribe(data => {
         this.router.navigate(["/furniture/all"]);
      })
  }

  pageChanged(page : number){
    this.currentPage = page;
  }

}



