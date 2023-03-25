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
    }
}