<template>
  <div class="col-5">
    <div class="row align-items-center bg-white nav-height rounded">
      <div class="col-md-4 text-center nav-link">
        Home
      </div>
      <div class="col-md-4 text-center nav-link">
        My Recipes
      </div>
      <div class="col-md-4 text-center nav-link">
        Favorites
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    return {}
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
