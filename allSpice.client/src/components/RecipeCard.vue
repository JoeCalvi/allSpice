<template>
    <div class="RecipeCard">
        <div class="col-md-4">
            <div class="card recipe-card selectable" data-bs-toggle="modal" data-bs-target="#recipe-details">
                <div class="col-md-12">
                    <div class="row justify-content-between">
                        <div class="col-3">
                            <div class="glass-card d-flex justify-content-center align-items-center m-1 rounded-pill">
                                <span class="p-1">Soups</span>
                            </div>
                        </div>
                        <div class="col-2">
                            <div class="glass-card d-flex justify-content-center align-items-center m-1 rounded-pill">
                                <i class="mdi mdi-heart-outline"></i>
                            </div>
                        </div>
                    </div>
                    <div class="row useless-height"></div>
                    <div class="row justify-content-center">
                        <div class="col-md-11 glass-card rounded">
                            <div class="mt-2">
                                <h5>Ridiculous Soup Dish</h5>
                            </div>
                            <div class="mb-2 pb-1">
                                <span>A delightful meal if you don't like actual food.</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Modal id="recipe-details">
        <RecipeDetails />
    </Modal>
</template>


<script>
import RecipeDetails from './RecipeDetails.vue';

export default {
    setup() {
        return {};
    },
    components: { RecipeDetails }
}
</script>


<style lang="scss" scoped>
.recipe-card {
    background-image: url(https://images.unsplash.com/photo-1547592166-23ac45744acd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1171&q=80);
    background-position: center;
    background-size: cover;
    height: 385px;
    width: 385px;
    box-shadow: 5px 5px 10px #5a5a5a;
}

.glass-card {
    background: #74737366;
    border: 1px solid #F4F4F4;
    backdrop-filter: blur(10px);
    color: white;
    text-shadow: 1px 2px 2px black;
}

.useless-height {
    height: 16em;
}
</style>