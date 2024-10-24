using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCode.DAL;
using WineCode.Models;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public KindsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Kinds
        [HttpGet]
        public ActionResult<IEnumerable<Kind>> GetKinds()
        {
            var kinds = _uow.KindRepository.GetAll();
            return Ok(kinds);
        }

        // GET: api/Kinds/5
        [HttpGet("{id}")]
        public ActionResult<Kind> GetKind(int id)
        {
            var kind = _uow.KindRepository.GetByID(id);

            if (kind == null)
            {
                return NotFound();
            }

            return Ok(kind);
        }

        // PUT: api/Kinds/5
        [HttpPut("{id}")]
        public IActionResult PutKind(int id, Kind kind)
        {
            if (id != kind.KindId)
            {
                return BadRequest();
            }

            _uow.KindRepository.Update(kind);

            try
            {
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Kinds
        [HttpPost]
        public ActionResult<Kind> PostKind(Kind kind)
        {
            _uow.KindRepository.Insert(kind);
            _uow.Save();

            return CreatedAtAction("GetKind", new { id = kind.KindId }, kind);
        }

        // DELETE: api/Kinds/5
        [HttpDelete("{id}")]
        public IActionResult DeleteKind(int id)
        {
            var kind = _uow.KindRepository.GetByID(id);
            if (kind == null)
            {
                return NotFound();
            }

            _uow.KindRepository.Delete(id);
            _uow.Save();

            return NoContent();
        }

        private bool KindExists(int id)
        {
            return _uow.KindRepository.GetByID(id) != null;
        }
    }
}
