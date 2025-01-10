
using System.Net.WebSockets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_REL2.Data;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class Pokemoncontroller:Controller
    {
        private readonly IPokimonRepository _pokimonRepository;
        private readonly IMapper _mapper;
        private object _Mapper;

        public Pokemoncontroller(IPokimonRepository pokimonRepository,IMapper mapper)
        {
            _pokimonRepository= pokimonRepository;
            _mapper= mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public IActionResult GetPokimons()
        {
          
            var pokemans= _mapper.Map<List<PokemonDto>>(_pokimonRepository.GetPokimons());  
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemans);
        }

        [HttpGet("{pokeid}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeid)
        {
            if (_pokimonRepository.GetPokemon(pokeid)==null)
            {
                return NotFound();
            }
            var pokemon= _pokimonRepository.GetPokemon(pokeid);

        
            return Ok(pokemon);
        }

        [HttpGet("{pokeid}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonRating(int pokeid)
        {
            if (!_pokimonRepository.PokemonExixst(pokeid))
            {
                return NotFound();
            }
            var rating = _pokimonRepository.GetPokemonRating(pokeid);

           /* if (ModelState.IsValid)
            {
                return BadRequest();
            }*/
            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int oid, [FromQuery] int cid,[FromBody] PokemonDto pok)
        {
            if (pok == null)
            {
                return BadRequest(ModelState);
            }
            var pokemon = _pokimonRepository.GetPokimons().Where(c => c.Name.Trim().
            ToUpper() == pok.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (pokemon != null)
            {
                ModelState.AddModelError("", "Pokemon already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var pokemonm = _mapper.Map<Pokemon>(pok);
           
            if (!_pokimonRepository.CreatePokemon(oid,cid,pokemonm))
            {
                ModelState.AddModelError("", "Error while saving data");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");

        }


        [HttpPut("{pid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdatePokemon(int pid, [FromBody] PokemonDto cat)
        {
            if (cat == null)
            {
                return BadRequest(ModelState);
            }
            if (pid != cat.Id)
            { return BadRequest(ModelState); }

            if (!_pokimonRepository.PokemonExixst(pid))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cm = _mapper.Map<Pokemon>(cat);
            if (!_pokimonRepository.UpdatePokemon(cm))
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

        public IActionResult DeletePokemon(int cid)
        {
            if (!_pokimonRepository.PokemonExixst(cid))
            {
                return NotFound();
            }
            var cd = _pokimonRepository.GetPokemon(cid);
           
            if (!_pokimonRepository.DeletePokemon(cd))
            {
                ModelState.AddModelError("", "someting went to wrong");
            }
            return NoContent();
        }
    }
}
