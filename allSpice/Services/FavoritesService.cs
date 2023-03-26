namespace allSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.CreateFavorite(favoriteData);
            return favorite;
        }

        internal string DeleteFavorite(int favoriteId, string userId)
        {
            Favorite favorite = _repo.GetOneFavorite(favoriteId);
            if(favorite == null) throw new Exception("Recipe was either already unfavorited or removed by its creator.");
            if(favorite.AccountId != userId) throw new Exception("You can only remove your own favorites.");
            _repo.DeleteFavorite(favoriteId);
            return "Recipe unfavorited.";
        }

        internal List<Favorite> GetFavorites()
        {

            List<Favorite> favorites = _repo.GetFavorites();
            return favorites;
        }

        internal Favorite GetOneFavorite(int id)
        {
            Favorite favorite = _repo.GetOneFavorite(id);
            return favorite;
        }
    }
}