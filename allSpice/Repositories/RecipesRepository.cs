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

        internal Recipe GetRecipeById(int id)
        {
            string sql = @"
            SELECT
            rec.*,
            acct.*
            FROM recipes rec
            JOIN accounts acct ON rec.creatorId = acct.id
            WHERE rec.id = @id;
            ";
            Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) => 
            {
                recipe.CreatorId = account.Id;
                return recipe;
            }, new { id }).FirstOrDefault();
            return recipe;
        }
    }
}