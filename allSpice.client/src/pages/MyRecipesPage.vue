<template>
    <div class="MyRecipesPage">
        <div class="container-fluid">
            <div class="row">
                <RecipeCard v-for="recipe in myRecipes" :recipe="recipe" />
            </div>
        </div>
    </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    setup() {
        function getMyRecipes() {
            try {
                const accountId = AppState.account.id;
                recipesService.getMyRecipes(accountId);
            }
            catch (error) {
                logger.error(error);
                Pop.error(error);
            }
        }
        onMounted(() => {
            getMyRecipes();
        });
        return {
            account: computed(() => AppState.account),
            myRecipes: computed(() => AppState.myRecipes)
        };
    },
    components: { RecipeCard }
}
</script>


<style lang="scss" scoped></style>