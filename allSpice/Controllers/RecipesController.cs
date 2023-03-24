namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, Auth0Provider auth)
        {
            _recipesService = recipesService;
            _auth = auth;
        }

        [HttpGet]
        public ActionResult <List<Recipe>> GetAllRecipes()
        {
            try 
            {
              List<Recipe> recipes = _recipesService.GetAllRecipes();
              return Ok(recipes);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult <Recipe> GetRecipeById(int id)
        {
            try 
            {
              Recipe recipe = _recipesService.GetRecipeById(id);
              return Ok(recipe);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        async public Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              recipeData.CreatorId = userInfo.Id;
              Recipe recipe = _recipesService.CreateRecipe(recipeData);
              recipe.Creator = userInfo;
              return Ok(recipe);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}