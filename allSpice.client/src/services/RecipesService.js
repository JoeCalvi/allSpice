import { AppState } from "../AppState";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

    async getAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data
        logger.log(AppState.recipes)
    }

    setActiveRecipe(recipeId) {
        AppState.activeRecipe = AppState.recipes.find(r => r.id == recipeId)
        logger.log(AppState.activeRecipe)
    }
}

export const recipesService = new RecipesService();