
//using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_REL2.Data;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;
using WEBAPI_REL2.Repository;

namespace WEBAPI_REL2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OwnerController: Controller
    {
        private readonly ICountryRepository _conRep;
        private readonly IOwnerRepository _orep;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository orep,ICountryRepository conRep,IMapper mapper)
        {
            _conRep= conRep;
            _orep=orep;
            _mapper=mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Owner))]
        public IActionResult GetOwners()
        {

            var own = _mapper.Map<List<OwnerDto>>(_orep.GetOwners());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(own);
        }

        [HttpGet("{oid}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int oid)
        {
            if (_orep.GetOwner(oid) == null)
            {
                return NotFound();
            }
            var own = _orep.GetOwner(oid);

            
            return Ok(own);
        }

        [HttpGet("{oid}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
       public IActionResult GetPokemonByOwner(int oid)
        {
            if(!_orep.OwnerExists(oid))
            {
                return NotFound();
            }

            var owner=_mapper.Map<List<OwnerDto>>(
                _orep.GetPokemonByOwner(oid)
                );
            return Ok(owner);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int cid,[FromBody] OwnerDto own)
        {
            if (own == null)
            {
                return BadRequest(ModelState);
            }
            var owner = _orep.GetOwners().Where(c => c.name.Trim().
            ToUpper() == own.name.TrimEnd().ToUpper()).FirstOrDefault();


            if (owner != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var oo = _mapper.Map<Owner>(own);

            oo.country = _conRep.GetCountry(cid);
            if (!_orep.CreateOwner(oo))
            {
                ModelState.AddModelError("", "Error while saving data");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");

        }

        [HttpPut("{oid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateOwner(int oid, [FromBody] CountryDto cat)
        {
            if (cat == null)
            {
                return BadRequest(ModelState);
            }
            if (oid != cat.Id)
            { return BadRequest(ModelState); }

            if (!_orep.OwnerExists(oid))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cm = _mapper.Map<Owner>(cat);
            if (!_orep.UpdateOwner(cm))
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

        public IActionResult DeleteOwner(int cid)
        {
            if (!_orep.OwnerExists(cid))
            {
                return NotFound();
            }
            var cd = _orep.GetOwner(cid);
            
            if (!_orep.DeleteOwner(cd))
            {
                ModelState.AddModelError("", "someting went to wrong");
            }
            return NoContent();
        }

    }
}
