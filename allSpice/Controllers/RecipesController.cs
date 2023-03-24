namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;

        public RecipesController(RecipesService recipesService)
        {
            _recipesService = recipesService;
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
    }
}