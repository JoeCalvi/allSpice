<template>
    <div class="RecipeDetails">
        <div class="container-fluid">
            <div class="row">
                <div :style="`background-image: url(${recipe?.img})`"
                    class="col-lg-4 recipe-img rounded-start d-flex justify-content-end">
                    <div class="card favorite-heart d-flex justify-content-center align-items-center">
                        <i v-if="favorite?.recipeId == recipe?.id && favorite?.accountId == account?.id"
                            @click="unfavoriteRecipe(`${favorite?.id}`)" class="mdi mdi-heart text-danger selectable"></i>
                        <i v-else @click="favoriteRecipe(`${recipe?.id}`)" class="mdi mdi-heart-outline selectable"></i>
                    </div>
                </div>
                <div class="col-lg-8 d-flex flex-column justify-content-between">
                    <div class="row mt-3">
                        <div class="col-lg-12 d-flex align-items-center justify-content-between mb-2">
                            <div>
                                <span class="recipe-title">
                                    {{ recipe?.title }}
                                    <span class="p-2 ms-3 mb-2 text-center glass-card rounded-pill">
                                        {{ recipe?.category }}
                                    </span>
                                </span>
                            </div>
                            <div>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                        </div>
                        <span class="recipe-description">added by {{ recipe?.creator.name }}</span>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="card mt-3">
                                <div class="card-header text-center header-color">
                                    Recipe Instructions
                                </div>
                                <div class="card-body recipe-instructions">
                                    <div class="mb-2">
                                        {{ recipe?.instructions }}
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 mb-2">
                            <div class="card mt-3">
                                <div class="card-header text-center header-color">
                                    Ingredients
                                </div>
                                <div class="card-body recipe-instructions">
                                    <ul>
                                        <li v-for="i in ingredients">
                                            {{ i?.quantity }} {{ i?.name }}
                                        </li>
                                    </ul>
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
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {

    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredients),
            favorite: computed(() => AppState.favorites.find(f => f.recipeId == AppState.activeRecipe?.id)),
            account: computed(() => AppState.account),

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
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.recipe-img {
    background-size: cover;
    background-position: center;
    height: 70vh;
}

.glass-card {
    background: #74737366;
    border: 1px solid #F4F4F4;
    backdrop-filter: blur(10px);
    color: white;
    text-shadow: 1px 2px 2px black;
    width: 5em;
}

.favorite-heart {
    background: #74737366;
    border: 1px solid #F4F4F4;
    border-top-style: hidden;
    border-radius: 0%;
    backdrop-filter: blur(10px);
    font-size: 24px;
    font-weight: lighter;
    color: white;
    text-shadow: 1px 2px 2px black;
    width: 40px;
    height: 30px;
}

.recipe-title {
    color: #219653;
}

.recipe-description {
    color: #717070;
}

.recipe-instructions {
    overflow-y: scroll;
    scroll-behavior: auto;
    height: 50vh;
}

.header-color {
    background-color: #527360;
    color: white;
    font-family: Roboto;
}
</style>