using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCode.DAL;
using WineCode.Models;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RecipesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Recipes
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetRecipes()
        {
            // Include the Wines navigation property when retrieving recipes
            //var recipes = _uow.RecipeRepository.Get(includes: r => r.Wines);
            var recipes = _uow.RecipeRepository.Get(
                includes: new List<Expression<Func<Recipe, object>>>
                {
                    r => r.Wines  // Include Wines
                });
            return Ok(recipes);
        }

        // POST: api/Recipes
        [HttpPost]
        public ActionResult<Recipe> PostRecipe(Recipe recipe)
        {
            _uow.RecipeRepository.Insert(recipe);
            _uow.Save();
            return CreatedAtAction("GetRecipe", new { id = recipe.RecipeId }, recipe);
        }

        // GET: api/Recipes/name/{name}
        [HttpGet("{name}")]
        public ActionResult<Recipe> GetRecipeByName(string name)
        {
            //var recipe = _uow.RecipeRepository
            //    .Get(r => r.Name.Contains(name),
            //         includes: r => r.Wines) // Include Wines
            //    .FirstOrDefault();

            var recipe = _uow.RecipeRepository.Get(
                filter: r => r.Name.Contains(name),
                includes: new List<Expression<Func<Recipe, object>>>
                {
                    r => r.Wines  // Include Wines
                },
                thenIncludes: new List<Func<IQueryable<Recipe>, IQueryable<Recipe>>>
                {
                    query => query.Include(r => r.Wines).ThenInclude(w => w.Country),
                    query => query.Include(r => r.Wines).ThenInclude(w => w.Kind),
                    query => query.Include(r => r.Wines).ThenInclude(w => w.Category)
                }
            ).FirstOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }

            if (recipe.Wines != null)
            {
                // Order wines, placing favorites first
                recipe.Wines = recipe.Wines.OrderByDescending(w => w.Favorite).ToList();
            }

            return Ok(recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = _uow.RecipeRepository.GetByID(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _uow.RecipeRepository.Delete(id);
            _uow.Save();
            return NoContent();
        }

        private bool RecipeExists(int id)
        {
            return _uow.RecipeRepository.GetByID(id) != null;
        }
    }
}
