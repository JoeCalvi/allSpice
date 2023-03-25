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

        internal List<Favorite> GetFavorites(string userId)
        {

            List<Favorite> favorites = _repo.GetFavorites(userId);
            return favorites;
        }

        internal Favorite GetOneFavorite(int id)
        {
            Favorite favorite = _repo.GetOneFavorite(id);
            return favorite;
        }
    }
}