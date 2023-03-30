import { AppState } from "../AppState"
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop"
import { api } from "./AxiosService.js"


class IngredientsService {

    async deleteIngredient(ingredientId) {
        let ingredientIndex = AppState.ingredients.findIndex(i => i.id == ingredientId)
        if (ingredientIndex == -1) {
            Pop.toast("Ingredient not found.", "error", "center", 3000, true)
            return
        } else {
            const res = await api.delete(`api/ingredients/${ingredientId}`)
            AppState.ingredients.splice(ingredientIndex, 1)
        }
    }
}

export const ingredientsService = new IngredientsService()