//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WineCode.DAL;
//using WineCode.Models;

//namespace WineAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FavoritesController : ControllerBase
//    {
//        private readonly IUnitOfWork _uow;

//        public FavoritesController(IUnitOfWork uow)
//        {
//            _uow = uow;
//        }

//        // In your FavoritesController
//        [HttpGet]
//        //public ActionResult<IEnumerable<Favorite>> GetFavorites()
//        //{
//        //    var favorites = _uow.FavoriteRepository.Get(
//        //        includes: f => f.FavoriteWines, // Gewoon de FavoriteWines opnemen
//        //        orderBy: q => q.OrderBy(f => f.FavoriteId) // Voorbeeld sortering
//        //    );

//        //    return Ok(favorites);
//        //}



//        // GET: api/Favorites/5
//        [HttpGet("{id}")]
//        public ActionResult<Favorite> GetFavorite(int id)
//        {
//            var favorite = _uow.FavoriteRepository.GetByID(id);

//            if (favorite == null)
//            {
//                return NotFound();
//            }

//            return Ok(favorite);
//        }

//        // PUT: api/Favorites/5
//        [HttpPut("{id}")]
//        public IActionResult PutFavorite(int id, Favorite favorite)
//        {
//            if (id != favorite.FavoriteId)
//            {
//                return BadRequest();
//            }

//            _uow.FavoriteRepository.Update(favorite);

//            try
//            {
//                _uow.Save();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!FavoriteExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Favorites
//        [HttpPost]
//        public ActionResult<Favorite> PostFavorite(Favorite favorite)
//        {
//            _uow.FavoriteRepository.Insert(favorite);
//            _uow.Save();

//            return CreatedAtAction("GetFavorite", new { id = favorite.FavoriteId }, favorite);
//        }

//        // DELETE: api/Favorites/5
//        [HttpDelete("{id}")]
//        public IActionResult DeleteFavorite(int id)
//        {
//            var favorite = _uow.FavoriteRepository.GetByID(id);
//            if (favorite == null)
//            {
//                return NotFound();
//            }

//            _uow.FavoriteRepository.Delete(id);
//            _uow.Save();

//            return NoContent();
//        }

//        private bool FavoriteExists(int id)
//        {
//            return _uow.FavoriteRepository.GetByID(id) != null;
//        }
//    }
//}
