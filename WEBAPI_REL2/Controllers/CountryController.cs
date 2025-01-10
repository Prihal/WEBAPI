using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;
using WEBAPI_REL2.Repository;

namespace WEBAPI_REL2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CountryController:Controller
    {
        private readonly ICountryRepository _conrep;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository conrep,IMapper mapper) 
        {
            _conrep=conrep;
            _mapper=mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetAllCountry()
        {

            var cou = _mapper.Map<List<CountryDto>>(_conrep.GetAllCountry());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cou);
        }

        [HttpGet("{cid}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int cid)
        {
            if (_conrep.GetCountry(cid)==null)
            {
                return NotFound();
            }
            var cat = _mapper.Map<CountryDto>(_conrep.GetCountry(cid));

            
            return Ok(cat);
        }

        [HttpGet("/Owner/{oid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        IActionResult GetOwnerFromACountry(int oid)
        {
            var gpbcid = _mapper.Map<List<CountryDto>>(_conrep.GetOwnerFromACountry(oid));
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(gpbcid);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto cat)
        {
            if (cat == null)
            {
                return BadRequest(ModelState);
            }
            var catagory = _conrep.GetAllCountry().Where(c => c.name.Trim().
            ToUpper() == cat.name.TrimEnd().ToUpper()).FirstOrDefault();

            if (catagory != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var catm = _mapper.Map<Country>(cat);
            if (!_conrep.CreateCountry(catm))
            {
                ModelState.AddModelError("", "Error while saving data");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");

        }

        [HttpPut("{cid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateCountry(int cid, [FromBody] CountryDto cat)
        {
            if (cat == null)
            {
                return BadRequest(ModelState);
            }
            if (cid != cat.Id)
            { return BadRequest(ModelState); }

            if (!_conrep.CountryExist(cid))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cm = _mapper.Map<Country>(cat);
            if (!_conrep.UpdateCountry(cm))
            {
                ModelState.AddModelError("", "Something went to wrong ");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{cid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]

        public IActionResult DeleteCountry(int cid)
        {
            if (!_conrep.CountryExist(cid))
            {
                return NotFound();
            }
            var cd = _conrep.GetCountry(cid);
            
            if (!_conrep.DeleteCountry(cd))
            {
                ModelState.AddModelError("", "someting went to wrong");
            }
            return NoContent();
        }
    }
}
