<template>
  <div class="container-fluid">
    <div class="row">
      <RecipeCardVue v-for="recipe in recipes" :recipe="recipe" />
    </div>
  </div>
</template>

<script>
import Navbar from '../components/Navbar.vue';
import RecipeCardVue from '../components/RecipeCard.vue';
import Modal from '../components/Modal.vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from "../services/RecipesService.js";
import { onMounted, computed } from 'vue';
import { AppState } from '../AppState';

export default {
  setup() {

    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes()
      } catch (error) {
        logger.log(error)
        Pop.error(error)
      }
    }

    onMounted(() => {
      getAllRecipes();
    })
    return {
      recipes: computed(() => AppState.recipes)
    };
  },
  components: { Navbar, RecipeCardVue, Modal }
}
</script>

<style scoped lang="scss"></style>
