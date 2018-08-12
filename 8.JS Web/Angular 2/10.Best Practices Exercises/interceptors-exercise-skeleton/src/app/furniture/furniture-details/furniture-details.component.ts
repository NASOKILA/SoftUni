import { Component, OnInit } from '@angular/core';
import { FurnitureModel } from '../models/furniture.model';
import { FurntureService } from '../furnture.service';
import { Route } from '@angular/compiler/src/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-furniture-details',
  templateUrl: './furniture-details.component.html',
  styleUrls: ['./furniture-details.component.css']
})
export class FurnitureDetailsComponent implements OnInit {

  furniture : FurnitureModel;

  constructor(
    private furnitureService : FurntureService, 
    private route : ActivatedRoute) { }

  ngOnInit() {

    let id = this.route.snapshot.params["id"];
    
    this.furnitureService.furnitureDetails(id)
      .subscribe(data => {
        this.furniture = data;
      });



  }

}
