using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCode.DAL;
using WineCode.Models;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CountriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Countries
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            var countries = _uow.CountryRepository.GetAll();
            return Ok(countries);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public ActionResult<Country> GetCountry(int id)
        {
            var country = _uow.CountryRepository.GetByID(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public IActionResult PutCountry(int id, Country country)
        {
            if (id != country.CountryId)
            {
                return BadRequest();
            }

            _uow.CountryRepository.Update(country);

            try
            {
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        [HttpPost]
        public ActionResult<Country> PostCountry(Country country)
        {
            _uow.CountryRepository.Insert(country);
            _uow.Save();

            return CreatedAtAction("GetCountry", new { id = country.CountryId }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _uow.CountryRepository.GetByID(id);
            if (country == null)
            {
                return NotFound();
            }

            _uow.CountryRepository.Delete(id);
            _uow.Save();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _uow.CountryRepository.GetByID(id) != null;
        }
    }
}
