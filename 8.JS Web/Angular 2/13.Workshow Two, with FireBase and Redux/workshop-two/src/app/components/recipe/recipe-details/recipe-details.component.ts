import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { RecipeListModel } from '../../../models/recipe-list.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AppState } from '../../../store/app.state';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})

export class RecipeDetailsComponent implements OnInit {

  recipe : Observable<RecipeListModel>
  id : string = this.route.snapshot.params["id"];

  constructor(private recipeService : RecipeService, 
    private route : ActivatedRoute,
    private store : Store<AppState>) { }

  ngOnInit() {

    this.recipeService.getRecipeById(this.id)
    .subscribe(() => {
      this.recipe = this.store.select(state => state.recipes.detail)
      console.log(this.recipe)
    })
  }

  delete(){

    this.recipeService
    .deleteRecipe(this.id);
  }
}