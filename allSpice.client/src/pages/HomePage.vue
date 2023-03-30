<template>
  <div class="container-fluid">
    <div class="row">
      <RecipeCardVue v-for="recipe in recipes" :recipe="recipe" />
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
import RecipeCardVue from '../components/RecipeCard.vue';
import Modal from '../components/Modal.vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from "../services/RecipesService.js";
import { onMounted, computed, watchEffect } from 'vue';
import { AppState } from '../AppState';

export default {
  setup() {

    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes()
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    onMounted(() => {
      getAllRecipes();
    })

    watchEffect(() => {
      if (AppState.account.id) { recipesService.getMyFavorites() }
    })

    return {
      recipes: computed(() => AppState.recipes)
    };
  },
  components: { RecipeCardVue, Modal }
}
</script>

<style scoped lang="scss"></style>
