import { Component, OnInit } from '@angular/core';
import { FurntureService } from '../furnture.service';
import { AuthService } from '../../authentication/auth.service';
import { FurnitureModel } from '../models/furniture.model';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { UserModel } from '../models/user.model';

@Component({
  selector: 'app-all-furniture',
  templateUrl: './all-furniture.component.html',
  styleUrls: ['./all-furniture.component.css']
})
export class AllFurnitureComponent implements OnInit {

  furnitures : FurnitureModel[];
  pageSize : number = 3;
  currentPage : number = 1;
  isAdmin : Boolean;
  
  constructor(private furnitureService : FurntureService,
    private authService : AuthService,
    private router : Router) { }

  ngOnInit() {
    this.isAdmin = this.authService.isAdmin();
    
    this.furnitureService.getAllfurniture()
    .subscribe(data => {
      this.furnitures = data;
    }); 
  }

  delete(id : string){
    this.furnitureService.deleteFurniture(id)
      .subscribe(data => {
         this.router.navigate(["/furniture/mine"]);
      })
  }

  pageChanged(page : number){
    this.currentPage = page;
  }
}
