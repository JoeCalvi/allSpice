namespace allSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = _repo.GetAllRecipes();
            return recipes;
        }

        internal Recipe GetRecipeById(int id)
        {
            Recipe recipe = _repo.GetRecipeById(id);
            if(recipe == null) throw new Exception("Recipe not found.");
            return recipe;
        }
        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.CreateRecipe(recipeData);
            return recipe;
        }

        internal Recipe EditRecipe(Recipe recipeData, string userId)
        {
            Recipe originalRecipe = this.GetRecipeById(recipeData.Id);
            if(originalRecipe.CreatorId != userId) throw new Exception("You can only edit recipes that you created.");
            originalRecipe.Title = recipeData.Title != null ? recipeData.Title : originalRecipe.Title;
            originalRecipe.Instructions = recipeData.Instructions != null ? recipeData.Instructions : originalRecipe.Instructions;
            originalRecipe.Img = recipeData.Img != null ? recipeData.Img : originalRecipe.Img;
            originalRecipe.Category = recipeData.Category != null ? recipeData.Category : originalRecipe.Category;
            originalRecipe.Favorited = recipeData.Favorited != null ? recipeData.Favorited : originalRecipe.Favorited;
            int rowsAffected = _repo.EditRecipe(originalRecipe);
            if(rowsAffected == 0) throw new Exception($"Could not edit {recipeData.Title} for some reason.");
            if(rowsAffected > 1) throw new Exception("You somehow edited more than one recipe...");
            return originalRecipe;
        }

        internal Recipe DeleteRecipe(int id, string userId)
        {
            Recipe recipe = this.GetRecipeById(id);
            if(recipe.CreatorId != userId) throw new Exception("This is not your recipe to delete.");
            _repo.DeleteRecipe(id);
            return recipe;
        }

    }
}