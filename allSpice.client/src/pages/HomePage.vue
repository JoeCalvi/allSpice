<template>
  <div class="container-fluid">
    <div class="row justify-content-center navbar-y">
      <Navbar />
    </div>
    <div class="row">
      <RecipeCardVue />
    </div>
  </div>
</template>

<script>
import Navbar from '../components/Navbar.vue';
import RecipeCardVue from '../components/RecipeCard.vue';
import Modal from '../components/Modal.vue';

export default {
  setup() {
    return {};
  },
  components: { Navbar, RecipeCardVue, Modal }
}
</script>

<style scoped lang="scss">
.navbar-y {
  transform: translateY(-30px);
}
</style>
