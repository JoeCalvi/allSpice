<template>
    <div class="RecipeCard col-lg-4 col-md-6 mb-3">
        <div class="card recipe-card" :style="`background-image: url(${recipe?.img})`">
            <div class="col-md-12 recipe-card-height d-flex flex-column justify-content-between">
                <div class="row justify-content-between align-items-center">
                    <div class="col-4">
                        <div @click="searchRecipes(`${recipe?.category}`)"
                            class="glass-card d-flex justify-content-center align-items-center m-1 rounded-pill selectable">
                            <span title="Bring Recipes of This Category to Top" class="p-1 text-center">{{ recipe?.category
                            }}</span>
                        </div>
                    </div>
                    <div v-if="account?.id" class="col-2">
                        <div class="glass-card d-flex justify-content-center align-items-center m-1 rounded-pill">
                            <i v-if="favorite?.recipeId == recipe?.id && favorite?.accountId == account?.id && recipe?.creatorId != account?.id"
                                @click="unfavoriteRecipe(`${favorite?.id}`)"
                                class="mdi mdi-heart text-danger selectable"></i>
                            <i v-else-if="recipe?.creatorId != account?.id" @click="favoriteRecipe(`${recipe?.id}`)"
                                class="mdi mdi-heart-outline selectable"></i>
                            <div v-else-if="recipe?.creatorId == account?.id" class="dropstart">
                                <button class="btn btn-outline text-white text-center" type="button"
                                    data-bs-toggle="dropdown" aria-expanded="false">...
                                </button>
                                <ul class="dropdown-menu">
                                    <li><button class="dropdown-item" @click="setActiveRecipe(`${recipe?.id}`)"
                                            type="button" data-bs-toggle="modal" data-bs-target="#edit-recipe"><i
                                                class="mdi mdi-pencil"></i> Edit
                                            Recipe</button>
                                    </li>
                                    <li><button class="dropdown-item" @click="deleteRecipe(`${recipe?.id}`)"><i
                                                class="mdi mdi-trash-can text-danger"></i> Delete Recipe</button></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div title="See Recipe Details" class="row justify-content-center">
                    <div @click="setActiveRecipe(`${recipe?.id}`)" class="col-md-11 glass-card rounded mb-2 selectable"
                        data-bs-toggle="modal" data-bs-target="#recipe-details">
                        <div class="mt-2 d-flex justify-content-between">
                            <h5>{{ recipe?.title }}</h5>

                        </div>
                        <div class="mb-2 pb-1">
                            <span>added by <span class="creator-font">{{ recipe.creator?.name }}</span></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import RecipeDetails from './RecipeDetails.vue';
import EditRecipeForm from './EditRecipeForm.vue'

export default {
    props: { recipe: { type: Object, required: true } },

    setup(props) {
        return {
            favorite: computed(() => AppState.favorites.find(f => f.recipeId == props.recipe.id)),
            account: computed(() => AppState.account),

            async setActiveRecipe(recipeId) {
                AppState.activeRecipe = null
                recipesService.setActiveRecipe(recipeId)
                await recipesService.getIngredientsByRecipeId(recipeId)
            },

            async favoriteRecipe(recipeId) {
                try {
                    await recipesService.favoriteRecipe(recipeId)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },

            async unfavoriteRecipe(favoriteId) {
                try {
                    await recipesService.unfavoriteRecipe(favoriteId)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },

            async deleteRecipe(recipeId) {
                try {
                    if (await Pop.confirm('Delete Recipe', 'Are you sure you want to delete this recipe? This action cannot be undone.', 'Delete', 'warning')) {
                        await recipesService.deleteRecipe(recipeId)
                    }
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },

            searchRecipes(query) {
                recipesService.searchRecipes({ query })
            }
        };
    },
    components: { RecipeDetails, EditRecipeForm }
}
</script>


<style lang="scss" scoped>
.recipe-card {
    background-position: center;
    background-size: cover;
    height: 385px;
    width: 385px;
    box-shadow: 5px 5px 10px #5a5a5a;
}

.recipe-card-height {
    height: 385px;
}

.creator-font {
    font-style: italic;
    color: white;
}

.glass-card {
    background: #74737366;
    border: 1px solid #F4F4F4;
    backdrop-filter: blur(10px);
    color: white;
    text-shadow: 1px 2px 2px black;
}
</style>