import { RecipeListModel } from "../../models/recipe-list.model";

export interface RecipesState {
    all: RecipeListModel[],
    detail : RecipeListModel,
    toEdit : RecipeListModel
}
