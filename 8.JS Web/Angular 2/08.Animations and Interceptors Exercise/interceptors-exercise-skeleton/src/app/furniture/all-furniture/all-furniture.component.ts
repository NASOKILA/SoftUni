import { Component, OnInit } from '@angular/core';
import { FurntureService } from '../furnture.service';
import { FurnitureModel } from '../models/furniture.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-all-furniture',
  templateUrl: './all-furniture.component.html',
  styleUrls: ['./all-furniture.component.css']
})
export class AllFurnitureComponent implements OnInit {

  furnitures : FurnitureModel[];

  constructor(private furnitureService : FurntureService) { }

  ngOnInit() {

    this.furnitureService.getAllfurniture()
    .subscribe(data => {
      this.furnitures = data;
    });
    
  }
}
