import { Component, OnInit } from '@angular/core';
import { RecipeListModel } from '../../../models/recipe-list.model';
import { Router, ActivatedRoute } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { NgForm } from '@angular/forms';
import { map } from 'rxjs/operators';
import { Store, select } from '@ngrx/store';
import { AppState } from '../../../store/app.state';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {

  recipe: RecipeListModel

  id: number;
  constructor(
    private recipeService: RecipeService,
    private route: ActivatedRoute,
    private router: Router,
    private store : Store<AppState>) { }

  ngOnInit() {

    let id = this.route.snapshot.params["id"];
    this.id = id;

    this.recipeService.getRecipeToEditById(id)
      .subscribe(() => {
        this.store
          .pipe(select(state => state.recipes.toEdit))
          .subscribe(recipeToEdit => this.recipe = recipeToEdit);
      });
  }

  editFormFunc() {

    let name = this.recipe.name;
    let imagePath = this.recipe.imagePath;
    let description = this.recipe.description;

    let id = this.id;
    let body = {
      [id]: {
        name,
        imagePath,
        description
      }
    }

    this.recipeService.editRecipe(body);      
  }

}
