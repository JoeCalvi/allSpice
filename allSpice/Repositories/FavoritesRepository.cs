namespace allSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite CreateFavorite(Favorite favoriteData, Recipe recipe)
        {
            string sql = @"
            INSERT INTO favorites
            (recipeId, accountId)
            VALUES
            (@recipeId, @accountId);
            SELECT LAST_INSERT_ID();
            ";

            int id = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = id;
            favoriteData.Recipe = recipe;
            return favoriteData;
        }

        internal void DeleteFavorite(int favoriteId)
        {
            string sql = @"
            DELETE FROM favorites
            WHERE id = @favoriteId;
            ";
            _db.Execute(sql, new { favoriteId });
        }

        internal List<Favorite> GetFavorites()
        {
            string sql = @"
            SELECT
            fav.*,
            rec.*,
            acct.*
            FROM favorites fav
            JOIN recipes rec ON fav.recipeId = rec.id
            JOIN accounts acct ON fav.accountId = acct.id;
            ";

            List<Favorite> favorites = _db.Query<Favorite, Recipe, Profile, Favorite>(sql, (favorite, recipe, profile) => 
            {
                favorite.RecipeId = recipe.Id;
                favorite.Recipe = recipe;
                favorite.Recipe.Creator = profile;
                return favorite;
            }).ToList();
            return favorites;
        }

        internal Favorite GetOneFavorite(int id)
        {
            string sql = @"
            SELECT
            fav.*,
            acct.*,
            rec.*
            FROM favorites fav
            JOIN accounts acct ON fav.accountId = acct.id
            JOIN recipes rec ON fav.recipeId = rec.id
            WHERE fav.id = @id;
            ";

            Favorite favorite = _db.Query<Favorite, Account, Recipe, Favorite>(sql, (favorite, account, recipe) => 
            {
                favorite.AccountId = account.Id;
                favorite.RecipeId = recipe.Id;
                favorite.Recipe = recipe;
                return favorite;
            }, new { id }).FirstOrDefault();
            return favorite;
        }
    }
}