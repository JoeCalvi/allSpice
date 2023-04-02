<template>
    <div class="FavoritesPage">
        <div class="container-fluid">
            <div class="row">
                <RecipeCard v-for="f in favorites" :recipe="f.recipe" />
            </div>
        </div>
    </div>

    <Modal id="recipe-details">
        <RecipeDetails />
    </Modal>
    <Modal id="edit-recipe">
        <EditRecipeForm />
    </Modal>
</template>


<script>
import { onMounted, computed, watchEffect } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import Modal from '../components/Modal.vue';

export default {
    setup() {
        async function getMyFavorites() {
            try {
                await recipesService.getMyFavorites();
            }
            catch (error) {
                logger.error(error);
                Pop.error(error);
            }
        }
        onMounted(() => {
            getMyFavorites();
        });

        watchEffect(() => {
            if (AppState.account.id) { recipesService.getMyFavorites() }
        })
        return {
            favorites: computed(() => AppState.favorites),
            recipes: computed(() => AppState.recipes)
        };
    },
    components: { RecipeCard, Modal }
}
</script>


<style lang="scss" scoped></style>