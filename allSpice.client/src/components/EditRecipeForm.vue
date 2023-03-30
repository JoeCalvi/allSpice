<template>
    <div class="EditRecipeForm">
        <div class="container-fluid">
            <div class="row">
                <div class="card-header text-end"><button class="btn btn-close me-3 mt-3" data-bs-dismiss="modal"
                        aria-label="Close"></button></div>
                <div class="col-lg-6 mb-3">
                    <div class="card mt-3">
                        <div class="card-header text-center header-color">
                            Recipe Instructions
                        </div>
                        <div class="card-body recipe-instructions">
                            <div class="mb-3">
                                <label for="instructions" class="form-label mb-3">Edit Instructions</label>
                                <textarea class="form-control" id="instructions"
                                    rows="8">{{ recipe?.instructions }}</textarea>
                            </div>
                            <div class="text-end">
                                <button class="btn btn-success">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-3">
                    <div class="card mt-3">
                        <div class="card-header text-center header-color">
                            Ingredients
                        </div>
                        <div class="card-body recipe-instructions">
                            <form @submit.prevent="addIngredient(recipe?.id)">
                                <label for="ingredients" class="form-label mb-3">Add Ingredient</label>
                                <div class="input-group mb-3">
                                    <input v-model="editableIngredient.name" type="text" id="name" class="form-control"
                                        placeholder="Ingredient Name" aria-label="Ingredient Name">
                                    <span class="input-group-text"><i class="mdi mdi-ampersand"></i></span>
                                    <input v-model="editableIngredient.quantity" type="text" id="quantity"
                                        class="form-control" placeholder="Ingredient Quantity"
                                        aria-label="Ingredient Quantity">
                                </div>
                                <div class="text-end">
                                    <button class="btn btn-success" type="submit">Add</button>
                                </div>
                            </form>
                            <div>
                                <div v-for="i in ingredients" @click="deleteIngredient(`${i?.id}`)"
                                    class="d-flex gap-3 align-items-center mb-2 p-2 border-bottom border-success">
                                    <button class="btn btn-close"></button> <span>{{ i?.quantity }} {{ i?.name }}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { ingredientsService } from "../services/IngredientsService.js";



export default {
    setup() {
        const editableIngredient = ref({})

        return {
            recipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredients),
            editableIngredient,

            async addIngredient(recipeId) {
                try {
                    await ingredientsService.addIngredient(recipeId, editableIngredient.value)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },

            async deleteIngredient(ingredientId) {
                try {
                    await ingredientsService.deleteIngredient(ingredientId)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.recipe-instructions {
    overflow-y: scroll;
    scroll-behavior: auto;
    height: 45vh;
}

.header-color {
    background-color: #527360;
    color: white;
    font-family: Roboto;
}
</style>