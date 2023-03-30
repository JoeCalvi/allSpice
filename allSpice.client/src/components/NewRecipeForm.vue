<template>
    <div class="NewRecipeForm">
        <div class="modal-header p-4 ">
            <span>New Recipe</span>
        </div>
        <div class="modal-body">
            <form @submit.prevent="createNewRecipe()">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="mb-3">
                                <label for="title" class="form-label">Title</label>
                                <input v-model="editable.title" type="text" class="form-control" id="title"
                                    placeholder="Recipe Title">
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="mb-3">
                                <label for="img" class="form-label">Image</label>
                                <input v-model="editable.img" type="text" class="form-control" id="img"
                                    placeholder="Recipe Image">
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="mb-3">
                                <label for="category" class="form-label">Category</label>
                                <select v-model="editable.category" class="form-select" aria-label="Category select">
                                    <option selected>Recipe Category</option>
                                    <option value="Appetizers">Appetizers</option>
                                    <option value="Comfort">Comfort</option>
                                    <option value="Italian">Italian</option>
                                    <option value="Mexican">Mexican</option>
                                    <option value="American">American</option>
                                    <option value="Asian">Asian</option>
                                    <option value="Dessert">Dessert</option>
                                    <option value="Beverages">Beverages</option>
                                </select>
                            </div>
                            <div class="mb-3">
                                <label for="instructions" class="form-label">Recipe Instructions</label>
                                <textarea v-model="editable.instructions" class="form-control" id="instructions"
                                    rows="10"></textarea>
                            </div>
                        </div>
                        <div class="col-lg-12 d-flex justify-content-end">
                            <div class="d-flex gap-3">
                                <button class="btn btn-outline-danger" data-bs-dismiss="modal"
                                    aria-label="Close">Cancel</button>
                                <button class="btn btn-success" type="submit">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>


<script>
import { ref } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,

            async createNewRecipe() {
                try {
                    const recipeData = editable.value
                    await recipesService.createNewRecipe(recipeData)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>