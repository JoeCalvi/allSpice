namespace allSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = _repo.GetAllIngredients();
            return ingredients;
        }
    }
}