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
    public class WinesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public WinesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Wines
        [HttpGet]
        public ActionResult<IEnumerable<Wine>> GetWines()
        {
            //var wines = _uow.WineRepository.GetAll();
            //var wines = _uow.WineRepository.Get(
            //null,
            //null, // No order
            //w => w.Country,           // Include Country
            //w => w.Categories,        // Include Categories
            //w => w.Kind);

            var wines = _uow.WineRepository.Get(
                filter: null,            // No filter
                orderBy: null,           // No order
                includes: new List<Expression<Func<Wine, object>>>
                {
                    w => w.Country,      // Include Country
                    w => w.Kind,          // Include Kind
                    w => w.Category,
                });


            return Ok(wines);
        }

        // GET: api/Wines/5
        [HttpGet("{id}")]
        public ActionResult<Wine> GetWine(int id)
        {
            var wine = _uow.WineRepository.GetByID(id);

            if (wine == null)
            {
                return NotFound();
            }

            return Ok(wine);
        }

        [HttpPut("{id}")]
        public IActionResult PutWine(int id, Wine wine)
        {
            if (id != wine.WineID)
            {
                return BadRequest();
            }

            // Update wine entity including its many-to-many relationships
            _uow.WineRepository.Update(wine);

            try
            {
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }


        // POST: api/Wines
        [HttpPost]
        public ActionResult<Wine> PostWine(Wine wine)
        {
            _uow.WineRepository.Insert(wine);
            _uow.Save();

            return CreatedAtAction("GetWine", new { id = wine.WineID }, wine);
        }

        // DELETE: api/Wines/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWine(int id)
        {
            var wine = _uow.WineRepository.GetByID(id);
            if (wine == null)
            {
                return NotFound();
            }

            _uow.WineRepository.Delete(id);
            _uow.Save();

            return NoContent();
        }

        //// GET: api/Recipes/name/{name}
        //[HttpGet("name/{name}")]
        //public ActionResult<Recipe> GetRecipeByName(string name)
        //{
        //    // Use the repository to filter by name
        //    var recipe = _uow.RecipeRepository.Get(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

        //    if (recipe == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(recipe);
        //}


        private bool WineExists(int id)
        {
            return _uow.WineRepository.GetByID(id) != null;
        }
    }
}
