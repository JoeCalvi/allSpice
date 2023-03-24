namespace allSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Recipe> GetAllRecipes()
        {
            string sql = @"
            SELECT
            *
            FROM recipes;
            ";
            List<Recipe> recipes = _db.Query<Recipe>(sql).ToList();
            return recipes;
        }
    }
}