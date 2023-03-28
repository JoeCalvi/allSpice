<template>
    <div class="RecipeDetails">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 recipe-img rounded-start d-flex justify-content-end">
                    <div class="card favorite-heart d-flex justify-content-center align-items-center">
                        <i class="mdi mdi-heart-outline"></i>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="row align-items-center justify-content-between mt-3">
                        <div class="col-md-10 d-flex align-items-center">
                            <h6 class="recipe-title">
                                Ridiculous Soup Dish
                            </h6>
                            <div class="ms-3 mb-2 text-center glass-card rounded-pill">
                                Soups
                            </div>
                        </div>
                        <div class="col-md-1 mb-1">
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                    </div>
                    <span class="recipe-description">A delightful meal if you don't like actual food.</span>
                    <div class="row">
                        <div class="col-6">
                            <div class="card mt-3">
                                <div class="card-header text-center header-color">
                                    Recipe Instructions
                                </div>
                                <div class="card-body recipe-instructions">
                                    <div class="mb-2">
                                        1. Lorem ipsum dolor, sit amet consectetur adipisicing elit. Quasi laudantium quis
                                        natus! Sit ut similique iste, praesentium obcaecati quos alias.
                                    </div>
                                    <div class="mb-2">
                                        2. Lorem ipsum dolor sit amet consectetur adipisicing elit. Ea ipsa soluta dolorum
                                        cupiditate commodi maxime consectetur, alias esse! Vitae, sed?
                                    </div>
                                    <div class="mb-2">
                                        3 Lorem, ipsum dolor sit amet consectetur adipisicing elit. Odit, repellat
                                        praesentium!
                                        Sit debitis natus molestias.
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="card mt-3">
                                <div class="card-header text-center header-color">
                                    Ingredients
                                </div>
                                <div class="card-body recipe-instructions">
                                    <ul>
                                        <li>
                                            2 tbsp garlic
                                        </li>
                                        <li>
                                            2 tbsp garlic
                                        </li>
                                        <li>
                                            2 tbsp garlic
                                        </li>
                                        <li>
                                            2 tbsp garlic
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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


<style lang="scss" scoped>
.recipe-img {
    background-image: url(https://images.unsplash.com/photo-1547592166-23ac45744acd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1171&q=80);
    background-size: cover;
    background-position: center;
    height: 60vh;
}

.glass-card {
    background: #74737366;
    border: 1px solid #F4F4F4;
    backdrop-filter: blur(10px);
    color: white;
    text-shadow: 1px 2px 2px black;
    width: 5em;
}

.favorite-heart {
    background: #74737366;
    border: 1px solid #F4F4F4;
    border-top-style: hidden;
    border-radius: 0%;
    backdrop-filter: blur(10px);
    font-size: 24px;
    font-weight: lighter;
    color: white;
    text-shadow: 1px 2px 2px black;
    width: 40px;
    height: 30px;
}

.recipe-title {
    color: #219653;
}

.recipe-description {
    color: #717070;
}

.recipe-instructions {
    overflow-y: scroll;
    scroll-behavior: auto;
    height: 42vh;
}

.header-color {
    background-color: #527360;
    color: white;
    font-family: Roboto;
}
</style>