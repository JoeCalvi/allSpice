namespace allSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
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
            rec.*
            FROM favorites fav
            JOIN recipes rec ON fav.recipeId = rec.id;
            ";

            List<Favorite> favorites = _db.Query<Favorite, Recipe, Favorite>(sql, (favorite, recipe) => 
            {
                favorite.RecipeId = recipe.Id;
                favorite.Recipe = recipe;
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