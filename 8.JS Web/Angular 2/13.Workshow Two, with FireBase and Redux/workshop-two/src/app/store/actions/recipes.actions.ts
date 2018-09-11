
import { Action } from '@ngrx/store'; //we can implement the actions as classes
import { RecipeListModel } from '../../models/recipe-list.model';

export const GET_ALL_RECIPES = '[RECIPES] Get All';
export const GET_RECIPE_DETAIL = '[RECIPES] Get Detail';
export const GET_RECIPE_TO_EDIT = '[RECIPES] Get recipe To Edit';

//action one
export class GetAllRecipes implements Action {
    type: string = GET_ALL_RECIPES;
    constructor(public payload : RecipeListModel[]){ }
}

//action two
export class GetRecipeDetail implements Action {
    type: string = GET_RECIPE_DETAIL;

    constructor(public payload : RecipeListModel){ }
}

//action three
export class GetRecipeToEdit implements Action {
    type: string = GET_RECIPE_TO_EDIT;

    constructor(public payload : RecipeListModel){ }
}


export type Types = GetAllRecipes | GetRecipeDetail | GetRecipeToEdit;