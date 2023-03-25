namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth;

        public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
        {
            _ingredientsService = ingredientsService;
            _auth = auth;
        }

        [HttpGet]
        public ActionResult<List<Ingredient>> GetAllIngredients()
        {
            try 
            {
              List<Ingredient> ingredients = _ingredientsService.GetAllIngredients();
              return Ok(ingredients);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]

        public ActionResult<Ingredient> AddIngredient([FromBody] Ingredient ingredientData)
        {
          try 
          {
            Ingredient ingredient = _ingredientsService.AddIngredient(ingredientData);
            return Ok(ingredient);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }
    }
}