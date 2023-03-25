namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth;
        private readonly IngredientsService _ingredientsService;

        public RecipesController(RecipesService recipesService, Auth0Provider auth, IngredientsService ingredientsService)
        {
            _recipesService = recipesService;
            _auth = auth;
            _ingredientsService = ingredientsService;
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

        [HttpGet("{id}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredientsInRecipe(int recipeId)
        {
          try 
          {
            List<Ingredient> ingredients = _ingredientsService.GetIngredientsInRecipe(recipeId);
            return Ok(ingredients);
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

        [HttpPut("{id}")]
        [Authorize]

        async public Task<ActionResult<Recipe>> EditRecipe(int id, [FromBody] Recipe recipeData)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              recipeData.Id = id;
              Recipe recipe = _recipesService.EditRecipe(recipeData, userInfo.Id);
              return Ok(recipe);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        async public Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              Recipe recipe = _recipesService.DeleteRecipe(id, userInfo.Id);
              return Ok(recipe);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}