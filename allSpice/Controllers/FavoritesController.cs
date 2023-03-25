namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;
        private readonly Auth0Provider _auth;

        public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
        {
            _favoritesService = favoritesService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        async public Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              favoriteData.AccountId = userInfo.Id;
              Favorite favorite = _favoritesService.CreateFavorite(favoriteData);
              return Ok(favorite);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        async public Task<ActionResult<List<Favorite>>> GetFavorites()
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              List<Favorite> favorites = _favoritesService.GetFavorites();
              return Ok(favorites);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Favorite> GetOneFavorite(int id)
        {
            try 
            {
              Favorite favorite = _favoritesService.GetOneFavorite(id);
              return Ok(favorite);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}