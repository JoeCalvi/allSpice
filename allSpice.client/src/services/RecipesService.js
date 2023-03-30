import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

    async getAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map(r => new Recipe(r))
        logger.log(AppState.recipes)
    }

    getMyRecipes(accountId) {
        AppState.myRecipes = AppState.recipes.filter(r => r.creatorId == accountId)
        logger.log(AppState.myRecipes)
    }

    setActiveRecipe(recipeId) {
        AppState.activeRecipe = AppState.recipes.find(r => r.id == recipeId)
        logger.log(AppState.activeRecipe)
    }

    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        AppState.ingredients = res.data
    }

    async getMyFavorites() {
        const res = await api.get('account/favorites')
        AppState.favorites = res.data.filter(f => f.accountId == AppState.account.id)
        logger.log(AppState.favorites)
    }
    async favoriteRecipe(recipeId) {
        await api.put(`api/recipes/${recipeId}`, { favorited: true })
        let recipe = AppState.recipes.find(r => r.id == recipeId)
        recipe.favorited = true

        const res = await api.post(`api/favorites`, { recipeId })
        AppState.favorites.push(res.data)
    }

    async unfavoriteRecipe(favoriteId) {
        const res = await api.delete(`api/favorites/${favoriteId}`)
        logger.log(res.data)
    }
}

export const recipesService = new RecipesService();