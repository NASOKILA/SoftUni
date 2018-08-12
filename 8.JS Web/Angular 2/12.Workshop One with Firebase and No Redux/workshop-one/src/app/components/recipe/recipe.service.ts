
import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { RecipeListModel } from '../../models/recipe-list.model';
import { ToastrService } from 'ngx-toastr';

const baseUrl = 'https://recipes-app-72484.firebaseio.com/recipes/';

@Injectable({
    providedIn: 'root' 
})
export class RecipeService {

    constructor(
        private http : HttpClient,
        private toast : ToastrService, 
        private router : Router){
    }

    getAllRecipes(){        
        return this.http.get<RecipeListModel[]>(`${baseUrl}.json`);
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