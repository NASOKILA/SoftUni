import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { RecipeListModel } from '../../../models/recipe-list.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})

export class RecipeDetailsComponent implements OnInit {

  recipe : RecipeListModel

  constructor(private recipeService : RecipeService, 
    private route : ActivatedRoute,
    private router : Router) { }

  ngOnInit() {

    let id = this.route.snapshot.params["id"];

    this.recipeService.getRecipeById(id)
    .subscribe(data => {
      this.recipe = data;
      this.recipe.id = id;
    })

  }

  delete(){

    this.recipeService
    .deleteRecipe(this.recipe.id);
  }
}