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
          class="mdi mdi-plus"></i></button>
    </div>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Login from "./components/Login.vue"
import CoverPhoto from './components/CoverPhoto.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Login, CoverPhoto }
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
