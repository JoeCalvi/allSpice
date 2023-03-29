import { AppState } from "../AppState";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

    async getAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data
        logger.log(AppState.recipes)
    }
}

export const recipesService = new RecipesService();