<template>
    <div class="CoverPhoto">
        <div class="container">
            <div class="row mt-3">
                <div class="col-12 cover-photo rounded">
                    <div class="row justify-content-end">
                        <div class="col-3 d-flex align-items-center">
                            <div class="me-2">
                                <form @submit.prevent="">
                                    <div class="input-group">
                                        <input type="text" class="form-control bg-white" placeholder="Search"
                                            aria-label="Search" aria-describedby="button-addon2">
                                        <button class="btn btn-light" type="button" id="button-addon2"><i
                                                class="mdi mdi-magnify"></i></button>
                                    </div>
                                </form>
                            </div>
                            <div>
                                <Login />
                            </div>
                        </div>
                    </div>
                    <div class="row justify-content-center align-items-center">
                        <div class="col-6 text-center all-spice">
                            <h1>
                                All-Spice
                            </h1>
                            <h6>Cherish Your Family<br> And Their Cooking.</h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>


<script>
import Login from './Login.vue';
export default {
    setup() {
        return {}
    },
    components: { Login }
}
</script>


<style lang="scss" scoped>
.cover-photo {
    background-image: url(https://images.unsplash.com/photo-1470549813517-2fa741d25c92?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80);
    background-position: center;
    background-size: cover;
    width: 1379px;
    height: 329px;
    box-shadow: 5px 5px 15px #5a5a5a;
}

.all-spice {
    color: white;
    text-shadow: 1px 2px 2px black;
    font-family: Sahitya;
    font-weight: lighter;
    font-style: italic;
}
</style>