<template>
    <div class="MyRecipesPage">
        <div class="container-fluid">
            <div class="row">
                <RecipeCard v-for="recipe in myRecipes" :recipe="recipe" />
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
import { computed, onMounted, watchEffect } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import Modal from '../components/Modal.vue';

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

        watchEffect(() => {
            if (AppState.account.id) { recipesService.getMyFavorites() }
        })
        return {
            account: computed(() => AppState.account),
            myRecipes: computed(() => AppState.myRecipes)
        };
    },
    components: { RecipeCard, Modal }
}
</script>


<style lang="scss" scoped></style>