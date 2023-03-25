namespace allSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;
        private readonly RecipesRepository _recRepo;

        public IngredientsService(IngredientsRepository repo, RecipesRepository recRepo)
        {
            _repo = repo;
            _recRepo = recRepo;
        }

        internal Ingredient AddIngredient(Ingredient ingredientData)
        {
            Ingredient ingredient = _repo.AddIngredient(ingredientData);
            return ingredient;
        }


        internal Ingredient EditIngredient(Ingredient ingredientData, string userId)
        {
            List<Ingredient> ingredients = _repo.GetAllIngredients();
            Ingredient originalIngredient = ingredients.Find(i => i.Id == ingredientData.Id);
            Recipe recipe = _recRepo.GetRecipeById(originalIngredient.RecipeId);
            if(recipe.CreatorId != userId) throw new Exception("You must be the one who shared this recipe to edit its ingredients.");
            originalIngredient.Name = ingredientData.Name != null ? ingredientData.Name : originalIngredient.Name;
            originalIngredient.Quantity = ingredientData.Quantity != null ? ingredientData.Quantity : originalIngredient.Quantity;
            int rowsAffected = _repo.EditIngredient(originalIngredient);
            if(rowsAffected == 0) throw new Exception("Nothing was changed.");
            if(rowsAffected > 1) throw new Exception("You edited more than one ingredient for some reason...");
            return originalIngredient;
        }

        internal List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = _repo.GetAllIngredients();
            return ingredients;
        }

        internal List<Ingredient> GetIngredientsInRecipe(int recipeId)
        {
            List<Ingredient> ingredients = _repo.GetIngredientsInRecipe(recipeId);
            return ingredients;
        }
        internal Ingredient DeleteIngredient(int id, string userId)
        {
            List<Ingredient> ingredients = _repo.GetAllIngredients();
            Ingredient ingredient = ingredients.Find(i => i.Id == id);
            Recipe recipe = _recRepo.GetRecipeById(ingredient.RecipeId);
            if(recipe.CreatorId != userId) throw new Exception("You must be the person who shared the recipe to delete its ingredients.");
            _repo.DeleteIngredient(id);
            return ingredient;
        }
    }
}