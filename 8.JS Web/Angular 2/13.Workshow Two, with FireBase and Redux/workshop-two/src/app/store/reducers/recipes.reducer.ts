import { RecipesState } from "../state/recipes.state";
import * as RecipesActions from '../actions/recipes.actions';
//we need to have an initial state otherwise it throws 'undefined'
const initialState: RecipesState = {
     all : [],
     detail: null,
     toEdit: null       
}


//pure function to update the state
function getAllRecipes(state, allRecipes){

    //Object assign takes 3 parameters and creates an object
    //param1 is an empty obj so it can fill it.
    //param2 is an object froom whch it copyies everything.
    //param3 is something new that we want to add in addition.
    return Object.assign({}, state, {all : allRecipes});
}

function getRecipeDetail(state, recipeDetails){

    return {
        ...state,
        detail : recipeDetails
    }
}

function getRecipeToEdit(state, recipeToEdit){

    return {
        ...state,
        toEdit : recipeToEdit
    }
}


export function recipesReducer(
    state : RecipesState = initialState, 
    action : RecipesActions.Types){
    
    switch(action.type){

        case RecipesActions.GET_ALL_RECIPES:
            return getAllRecipes(state, action.payload);
        case RecipesActions.GET_RECIPE_DETAIL:
            return getRecipeDetail(state, action.payload);    
        case RecipesActions.GET_RECIPE_TO_EDIT:
            return getRecipeToEdit(state, action.payload);            
        default:
            return state;
    }
}