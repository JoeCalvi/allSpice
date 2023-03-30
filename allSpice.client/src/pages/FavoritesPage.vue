<template>
    <div class="FavoritesPage">
        <div class="container-fluid">
            <div class="row">
                <RecipeCard v-for="f in favorites" :recipe="f.recipe" />
            </div>
        </div>
    </div>
</template>


<script>
import { onMounted, computed } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

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
        return {
            favorites: computed(() => AppState.favorites)
        };
    },
    components: { RecipeCard }
}
</script>


<style lang="scss" scoped></style>