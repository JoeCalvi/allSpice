namespace allSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient AddIngredient(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (recipeId, name, quantity)
            VALUES
            (@recipeId, @name, @quantity);
            SELECT LAST_INSERT_ID();
            ";

            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            return ingredientData;
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