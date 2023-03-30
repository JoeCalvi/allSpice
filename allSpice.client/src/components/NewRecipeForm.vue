<template>
    <div class="NewRecipeForm">
        <div class="modal-header p-4 ">
            <span>New Recipe</span>
        </div>
        <div class="modal-body">
            <form @submit.prevent="">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="mb-3">
                                <label for="title" class="form-label">Title</label>
                                <input type="text" class="form-control" id="title" placeholder="Recipe Title">
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="mb-3">
                                <label for="img" class="form-label">Image</label>
                                <input type="text" class="form-control" id="img" placeholder="Recipe Image">
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="mb-3">
                                <label for="category" class="form-label">Category</label>
                                <select class="form-select" aria-label="Category select">
                                    <option selected>Recipe Category</option>
                                    <option value="1">Appetizers</option>
                                    <option value="2">Comfort</option>
                                    <option value="3">Italian</option>
                                    <option value="4">Mexican</option>
                                    <option value="5">American</option>
                                    <option value="6">Asian</option>
                                    <option value="7">Dessert</option>
                                    <option value="8">Beverages</option>
                                </select>
                            </div>
                            <div class="mb-3">
                                <label for="instructions" class="form-label">Recipe Instructions</label>
                                <textarea class="form-control" id="instructions" rows="10"></textarea>
                            </div>
                        </div>
                        <div class="col-lg-12 d-flex justify-content-end">
                            <div class="d-flex gap-3">
                                <button class="btn btn-outline-danger">Cancel</button>
                                <button class="btn btn-success">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
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


<style lang="scss" scoped></style>