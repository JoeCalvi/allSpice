<template>
    <div class="RecipeDetails">
        <div class="container-fluid">
            <div class="row">
                <div :style="`background-image: url(${recipe?.img})`"
                    class="col-md-4 recipe-img rounded-start d-flex justify-content-end">
                    <div class="card favorite-heart d-flex justify-content-center align-items-center">
                        <i class="mdi mdi-heart-outline selectable"></i>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="row align-items-center justify-content-between mt-3">
                        <div class="col-md-10 d-flex align-items-center">
                            <h6 class="recipe-title">
                                {{ recipe?.title }}
                            </h6>
                            <div class="ms-3 mb-2 text-center glass-card rounded-pill">
                                {{ recipe?.category }}
                            </div>
                        </div>
                        <div class="col-md-1 mb-1">
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                    </div>
                    <span class="recipe-description">added by {{ recipe?.creator.name }}</span>
                    <div class="row">
                        <div class="col-6">
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
                        <div class="col-6">
                            <div class="card mt-3">
                                <div class="card-header text-center header-color">
                                    Ingredients
                                </div>
                                <div class="card-body recipe-instructions">
                                    <ul>
                                        <li v-for="i in recipe?.ingredients">
                                            2 tbsp garlic
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

export default {

    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe)
        }
    }
}
</script>


<style lang="scss" scoped>
.recipe-img {
    background-size: cover;
    background-position: center;
    height: 60vh;
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
    height: 42vh;
}

.header-color {
    background-color: #527360;
    color: white;
    font-family: Roboto;
}
</style>