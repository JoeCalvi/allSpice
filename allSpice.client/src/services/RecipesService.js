import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";

class RecipesService {

    async getAllRecipes() {
        AppState.searchResults = []
        const res = await api.get('api/recipes')
        AppState.recipes = res.data
    }

    async createNewRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        AppState.recipes.push(res.data)
        AppState.myRecipes.push(res.data)
    }

    getMyRecipes(accountId) {
        AppState.myRecipes = AppState.recipes.filter(r => r.creatorId == accountId)
    }

    async deleteRecipe(recipeId) {
        const res = await api.delete(`api/recipes/${recipeId}`)
        let recipeIndex = AppState.recipes.findIndex(r => r.id == recipeId)
        AppState.recipes.splice(recipeIndex, 1)
    }

    setActiveRecipe(recipeId) {
        AppState.activeRecipe = AppState.recipes.find(r => r.id == recipeId)
    }

    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        AppState.ingredients = res.data
    }

    async getMyFavorites() {
        const res = await api.get('account/favorites')
        AppState.favorites = res.data
    }
    async favoriteRecipe(recipeId) {
        const res = await api.post(`api/favorites`, { recipeId })
        AppState.favorites.push(res.data)
    }

    async unfavoriteRecipe(favoriteId) {
        let favoriteIndex = AppState.favorites.findIndex(f => f.id == favoriteId)
        if (favoriteIndex == -1) {
            Pop.toast("Recipe not in favorites.", "info", "center", 3000, true)
            return
        } else {
            const res = await api.delete(`api/favorites/${favoriteId}`)
            AppState.favorites.splice(favoriteIndex, 1)
        }
    }

    async editInstructions(recipeId, instructionsData) {
        const res = await api.put(`api/recipes/${recipeId}`, instructionsData)
        AppState.activeRecipe = res.data
        let recipeIndex = AppState.recipes.findIndex(r => r.id == recipeId)
        AppState.recipes.splice(recipeIndex, 1, res.data)
    }

    searchRecipes(query) {
        let results = AppState.recipes.filter(r => r.category.toLowerCase() == query.query.toLowerCase())
        results.forEach(r => {
            let index = AppState.recipes.indexOf(r)
            AppState.recipes.splice(index, 1)
            AppState.recipes.unshift(r)
        })
    }
}

export const recipesService = new RecipesService();