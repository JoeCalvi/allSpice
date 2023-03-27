<template>
  <div class="container-fluid">
    <div class="row justify-content-center navbar-y">
      <Navbar />
    </div>
    <div class="row">
      <div class="col-md-4">
        <div class="card recipe-card">
          <div class="row justify-content-between">
            <div class="col-3">
              <div class="glass-card d-flex justify-content-center align-items-center m-1 rounded-pill">
                <span class="p-1">Soups</span>
              </div>
            </div>
            <div class="col-2">
              <div class="glass-card">
                <i class="mdi mdi-heart-outline"></i>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '../components/Navbar.vue';

export default {
  setup() {
    return {};
  },
  components: { Navbar }
}
</script>

<style scoped lang="scss">
.navbar-y {
  transform: translateY(-30px);
}

.recipe-card {
  background-image: url(https://images.unsplash.com/photo-1547592166-23ac45744acd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1171&q=80);
  background-position: center;
  background-size: cover;
  height: 385px;
  width: 385px;
}

.glass-card {
  background: rgba(218, 217, 217, 0.4);
  border: 1px solid #F4F4F4;
  backdrop-filter: blur(8px);
}
</style>
