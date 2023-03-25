namespace allSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal Ingredient AddIngredient(Ingredient ingredientData)
        {
            Ingredient ingredient = _repo.AddIngredient(ingredientData);
            return ingredient;
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
    }
}