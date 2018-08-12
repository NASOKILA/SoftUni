import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { Store } from '@ngrx/store';
import { AppState } from '../../../store/app.state';
import { RecipeListModel } from '../../../models/recipe-list.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-recipe-all',
  templateUrl: './recipe-all.component.html',
  styleUrls: ['./recipe-all.component.css']
})
export class RecipeAllComponent implements OnInit {

  allRecipes: Observable<RecipeListModel[]>
  constructor(
    private recipeService : RecipeService, 
    private store : Store<AppState>) { }

  ngOnInit() {

    this.recipeService.getAllRecipes().subscribe(() => {
      
      this.allRecipes = this.store.select(state => {
        return state.recipes.all;
      });

    })
  }
}
