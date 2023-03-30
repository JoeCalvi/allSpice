import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";

class RecipesService {

    async getAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data
        logger.log(AppState.recipes)
    }

    async createNewRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        AppState.recipes.push(res.data)
        AppState.myRecipes.push(res.data)
    }

    getMyRecipes(accountId) {
        AppState.myRecipes = AppState.recipes.filter(r => r.creatorId == accountId)
        logger.log(AppState.myRecipes)
    }

    async deleteRecipe(recipeId) {
        const res = await api.delete(`api/recipes/${recipeId}`)
        logger.log(res.data)
        let recipeIndex = AppState.recipes.findIndex(r => r.id == recipeId)
        AppState.recipes.splice(recipeIndex, 1)
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
        AppState.favorites = res.data
        logger.log(AppState.favorites)
    }
    async favoriteRecipe(recipeId) {
        const res = await api.post(`api/favorites`, { recipeId })
        AppState.favorites.push(res.data)
    }

    async unfavoriteRecipe(favoriteId) {
        let favoriteIndex = AppState.favorites.findIndex(f => f.id == favoriteId)
        logger.log("favoriteIndex:", favoriteIndex)
        if (favoriteIndex == -1) {
            Pop.toast("Recipe not in favorites.", "info", "center", 3000, true)
            return
        } else {
            const res = await api.delete(`api/favorites/${favoriteId}`)
            AppState.favorites.splice(favoriteIndex, 1)
            logger.log('res.data:', res.data, 'Appstate favs:', AppState.favorites)
        }
    }
}

export const recipesService = new RecipesService();