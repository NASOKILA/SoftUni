import { Component, OnInit } from '@angular/core';
import { CreateFurnitureModel } from '../models/create-furniture.model';
import { FurntureService } from '../furnture.service';

@Component({
  selector: 'app-create-furniture',
  templateUrl: './create-furniture.component.html',
  styleUrls: ['./create-furniture.component.css']
})
export class CreateFurnitureComponent implements OnInit {

  bindingModel : CreateFurnitureModel = new CreateFurnitureModel("", "", 0, "", 1, "",);;
  
  constructor(private furntureService : FurntureService) {
  }

  ngOnInit() { }

  create(){

    this.furntureService.createFurniture(this.bindingModel)
      .subscribe();
  }
}
