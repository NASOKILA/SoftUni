import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css']
})
export class RecipeCreateComponent implements OnInit {

  constructor(
    private recipeService : RecipeService, 
    private router : Router) { }  

  ngOnInit() {
  }

  createRecipe(form : NgForm){

    const name = form.value.name;
    const imagePath = form.value.imagePath;
    const description = form.value.description;
  
    this.recipeService
      .createRecipe(name, imagePath, description);
  }
}
