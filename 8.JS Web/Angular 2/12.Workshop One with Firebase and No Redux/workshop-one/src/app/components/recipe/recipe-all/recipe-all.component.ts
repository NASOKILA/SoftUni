import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipe-all',
  templateUrl: './recipe-all.component.html',
  styleUrls: ['./recipe-all.component.css']
})
export class RecipeAllComponent implements OnInit {

  allRecipes: any[] = []
  constructor(private recipeService: RecipeService) { }

  ngOnInit() {
    this.recipeService
      .getAllRecipes()
      .subscribe(data => {

        for (let index in data) {
          let element = data[index]
          element['id'] = index;
          this.allRecipes.push(element);
        }

      })
  }
}
