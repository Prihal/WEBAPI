using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;
using WEBAPI_REL2.Repository;

namespace WEBAPI_REL2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly ICatagoryRepository _catRep;
        private readonly IMapper _mapper;

        public CatagoryController(ICatagoryRepository catRep,IMapper mapper)
        {
            _catRep = catRep;
            _mapper=mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetCategories()
        {

            var cat = _mapper.Map<List<CatagoryDto>>(_catRep.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cat);
        }

        [HttpGet("{cid}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int cid)
        {
            var category = _catRep.GetCategory(cid);

            if (category == null)
            {
                // If category doesn't exist, return 404 Not Found
                return NotFound();
            }

            // Map the category to a CategoryDto
            var catDto = _mapper.Map<CatagoryDto>(category);

            // Return 200 with the CategoryDto
            return Ok(catDto);
        }
        [HttpGet("pokemons/{cid}")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        IActionResult GetPokemonByCatogory(int cid)
        {
            var gpbcid = _mapper.Map<List<PokemonDto>>(_catRep.GetPokemonByCatogory(cid));
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(gpbcid);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCatagory([FromBody] CatagoryDto cat)
        {
            if(cat == null)
            {
                return BadRequest(ModelState);
            }
            var catagory = _catRep.GetCategories().Where(c => c.Name.Trim().
            ToUpper() ==cat.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (catagory != null)
            {
                ModelState.AddModelError("", "Catagory already exists");
                return StatusCode(422,ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var catm = _mapper.Map<Category>(cat);
            if(!_catRep.CreateCategory(catm))
            {
                ModelState.AddModelError("", "Error while saving data");
                return StatusCode(500,ModelState);
            }
            return Ok("Successfully Created");

        }

        [HttpPut("{cid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateCategory(int cid, [FromBody] CatagoryDto cat)
        {
            if(cat == null)
            {
                return BadRequest(ModelState);
            }
            if(cid != cat.Id)
            { return BadRequest(ModelState); }

            if(!_catRep.CatagoryExist(cid))
            {
                return NotFound();
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState); }

            var cm=_mapper.Map<Category>(cat);
            if(!_catRep.UpdateCategory(cm))
            {
                ModelState.AddModelError("", "Something went to wrong ");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{cid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]

        public IActionResult DeleteCategory(int cid)
        {
            if (!_catRep.CatagoryExist(cid))
            {
                return NotFound();
            }
            var cd=_catRep.GetCategory(cid);
           
            if(!_catRep.DeleteCategory(cd))
            {
                ModelState.AddModelError("", "someting went to wrong");
            }
            return NoContent();
        }
    }
}
