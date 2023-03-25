namespace allSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Ingredient> GetAllIngredients()
        {
            string sql = @"
            SELECT 
            *
            FROM
            ingredients;
            ";

            List<Ingredient> ingredients = _db.Query<Ingredient>(sql).ToList();
            return ingredients;
        }
    }
}