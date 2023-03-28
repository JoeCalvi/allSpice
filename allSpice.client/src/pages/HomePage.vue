<template>
  <div class="container-fluid">
    <div class="row justify-content-center navbar-y">
      <Navbar />
    </div>
    <!-- <button data-bs-toggle="modal" data-bs-target="#recipe-details">CLICK ME</button> -->
    <div class="row">
      <RecipeCardVue />
    </div>
  </div>

  <!-- <Modal id="recipe-details">
    <img
      src="https://images.unsplash.com/photo-1547592166-23ac45744acd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1171&q=80"
      alt="">
  </Modal> -->
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
