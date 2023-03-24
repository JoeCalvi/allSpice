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
    }
}