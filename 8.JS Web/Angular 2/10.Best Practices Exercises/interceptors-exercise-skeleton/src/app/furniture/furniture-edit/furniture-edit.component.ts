import { Component, OnInit } from '@angular/core';
import { CreateFurnitureModel } from '../models/create-furniture.model';
import { FurntureService } from '../furnture.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { EditFurnitureModel } from '../models/edit-furniture.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-furniture-edit',
  templateUrl: './furniture-edit.component.html',
  styleUrls: ['./furniture-edit.component.css']
})

export class FurnitureEditComponent implements OnInit {

  bindingModel : EditFurnitureModel;
  
  constructor(private furntureService : FurntureService,
    private route : ActivatedRoute,
    private toastr : ToastrService,
    private router : Router
  ) {
  }

  ngOnInit() {
    let id = this.route.snapshot.params["id"];
    
    this.furntureService.getFurnitureById(id)
      .subscribe(data => {
        this.bindingModel = new EditFurnitureModel(
          data.id,
          data.make, 
          data.model, 
          data.year, 
          data.description, 
          data.price, 
          data.image, 
          data.material);
      });
  }

  update(){
  
    console.log('UPDATE HERE')
    this.furntureService.updateFurniture(this.bindingModel)
      .toPromise()
      .then(data => {

        this.toastr.success('Furniture edited successfully.', 'Success!');
        this.router.navigate(['/furniture/all']);
      })
      .catch(err => {
        this.toastr.error(err.message, 'Error!');
        
      });
  }

}
