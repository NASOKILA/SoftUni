import { RecipesState } from "./state/recipes.state";

//this will be our state
//we split the state into many pieces and then we combine it in this file.
export interface AppState {
    recipes: RecipesState,
}
