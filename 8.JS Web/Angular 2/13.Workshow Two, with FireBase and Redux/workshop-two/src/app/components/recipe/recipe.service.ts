
import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { RecipeListModel } from '../../models/recipe-list.model';
import { ToastrService } from 'ngx-toastr';
import { AppState } from '../../store/app.state';
import { Store } from '@ngrx/store';
import { GetAllRecipes, GetRecipeDetail, GetRecipeToEdit } from '../../store/actions/recipes.actions';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

const baseUrl = 'https://recipes-app-72484.firebaseio.com/recipes/';

@Injectable({
    providedIn: 'root' 
})
export class RecipeService {

    constructor(
        private http : HttpClient,
        private toast : ToastrService, 
        private router : Router,
        private store : Store<AppState>){}

    getAllRecipes(){        
        return this.http.get(`${baseUrl}.json`)
        .pipe(map((res : Response) => {

            const items = Object.keys(res);
            const recipes : RecipeListModel[] = [];
            
            for (let i of items) {
                let recipe = new RecipeListModel(
                    i, 
                    res[i].name, 
                    res[i].imagePath, 
                    res[i].description);
                
                recipes.push(recipe);
            }
            
            //we dispatch the recipes
            this.store.dispatch(new GetAllRecipes(recipes)) 
          }))
    }

    createRecipe(name : string, imagePath: string, description : string){        
        return this.http.post(`${baseUrl}.json`, {
            name,
            imagePath,
            description
        }).subscribe(data => {
            this.router.navigate(['/recipes/all']);        
            this.toast.success("Recipe created successfully!", "Success!");  
        });
    }

    getRecipeById(id : string){
        return this.http.get<RecipeListModel>(`${baseUrl}${id}.json`)
        .pipe(map((res : RecipeListModel) => {

            
            //we dispatch the recipes
            this.store.dispatch(new GetRecipeDetail(res)) 
          }))
    }


    getRecipeToEditById(id : string){
        return this.http.get<RecipeListModel>(`${baseUrl}${id}.json`)
        .pipe(map((res : RecipeListModel) => {

            
            //we dispatch the recipes BUt this time is to edit.
            this.store.dispatch(new GetRecipeToEdit(res)) 
          }))
    }


    deleteRecipe(id : string){
        return this.http.delete(`${baseUrl}${id}.json`)
        .subscribe(data => {
            this.router.navigate(["/recipes/all"])
            this.toast.success("Recipe deleted successfully!", "Success!");
        });
    }

    editRecipe(body : Object) {
        return this.http.patch(`${baseUrl}.json`, body)
        .subscribe(data => {
            this.toast.success("Recipe updated successfully!", "Success!");
            this.router.navigate(["/recipes/all"])
        });;
    }

}