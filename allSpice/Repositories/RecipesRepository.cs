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
            rec.*,
            acct.*
            FROM recipes rec
            JOIN accounts acct ON rec.creatorId = acct.id;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, account) => 
            {   
                recipe.Creator = account;
                recipe.CreatorId = account.Id;
                return recipe;
            }).ToList();
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
            Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, account) => 
            {
                recipe.CreatorId = account.Id;
                recipe.Creator = account;
                return recipe;
            }, new { id }).FirstOrDefault();
            return recipe;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (creatorId, title, instructions, img, category)
            VALUES
            (@creatorId, @title, @instructions, @img, @category);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }

        internal void DeleteRecipe(int id)
        {
            string sql = @"
            DELETE FROM recipes
            WHERE id = @id;
            ";

            _db.Execute(sql, new { id });
        }

        internal int EditRecipe(Recipe updatedRecipe)
        {
            string sql = @"
            UPDATE recipes
            SET
            title = @title,
            instructions = @instructions,
            img = @img,
            category = @category
            WHERE id = @id;
            ";

            int rows = _db.Execute(sql, updatedRecipe);
            return rows;
        }
    }
}