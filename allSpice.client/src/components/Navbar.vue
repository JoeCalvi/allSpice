<template>
  <div class="col-5">
    <div class="row align-items-center bg-white nav-height rounded">
      <div class="col-md-4 text-center nav-link">
        <router-link class="nav-link" :to="{ name: 'Home' }">
          Home
        </router-link>
      </div>
      <div class="col-md-4 text-center ">
        <router-link v-if="account?.id" class="nav-link" :to="{ name: 'MyRecipes' }">
          My Recipes
        </router-link>
        <div class="nav-link text-dark" title="Must Be Logged In To Access" v-else>My Recipes</div>
      </div>
      <div class="col-md-4 text-center">
        <router-link v-if="account?.id" class="nav-link" :to="{ name: 'Favorites' }">
          Favorites
        </router-link>
        <div class="nav-link text-dark" title="Must Be Logged In To Access" v-else>Favorites</div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-height {
  height: 70px;
  box-shadow: 5px 5px 10px #5a5a5a;
}

.nav-link {
  font-family: Sahitya;
  color: #219653;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
