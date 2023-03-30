<template>
  <header>
    <CoverPhoto />
  </header>
  <main>
    <div class="row justify-content-center navbar-y">
      <Navbar />
    </div>
    <router-view />
  </main>
  <footer class="sticky-bottom d-flex justify-content-end">
    <div class="pe-3">
      <button class="btn btn-success new-recipe-button rounded-circle d-flex justify-content-center align-items-center"><i
          class="mdi mdi-plus" data-bs-toggle="modal" data-bs-target="#new-recipe"></i></button>
    </div>
  </footer>

  <Modal id="new-recipe">
    <NewRecipeForm />
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState.js'
import Navbar from './components/Navbar.vue'
import Login from "./components/Login.vue"
import CoverPhoto from './components/CoverPhoto.vue'
import Modal from './components/Modal.vue'
import NewRecipeForm from './components/NewRecipeForm.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Login, CoverPhoto, Modal, NewRecipeForm }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.navbar-y {
  transform: translateY(-30px);
}

.modal-header {
  background-color: #527360;
  color: white;
  font-family: 'Sahitya';
  font-style: normal;
  font-weight: 400;
  font-size: 36px;
  line-height: 24px;
}

footer {
  display: grid;
  place-content: center;
  height: 12vh;
}

.new-recipe-button {
  height: 86px;
  width: 86px;
  font-size: 75px;
}
</style>
