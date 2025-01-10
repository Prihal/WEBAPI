using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReviewController:Controller
    {
        private readonly IReviewRepository _rrep;
        private readonly IMapper _mapper;
        private readonly IPokimonRepository _poki;
        private readonly IReviewerRepository _rview;

        public ReviewController(IReviewRepository rrep,
            IMapper mapper,
            IPokimonRepository poki,
            IReviewerRepository rview)
        {
            _rrep = rrep;
            _mapper = mapper;
            _poki= poki;
            _rview = rview;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Review))]
        public IActionResult GetReviews()
        {

            var own = _mapper.Map<List<ReviewDto>>(_rrep.GetReviews());
           

            return Ok(own);
        }

        [HttpGet("{rid}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int rid)
        {
            var r = _rrep.GetReview(rid);
            if (r==null)
            {
                return NotFound();
            }
            

           
            return Ok(r);
        }

        [HttpGet("{rid}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewByPokemon(int rid)
        {
            if (!_rrep.ReviewExist(rid))
            {
                return NotFound();
            }

            var owner = _mapper.Map<List<ReviewDto>>(
                _rrep.GetReviewByPokemon(rid)
                );
            return Ok(owner);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery] int reviewerid, [FromQuery] int pokemonid,[FromBody] ReviewDto reviewCreate)
        {
            if (reviewCreate == null)
            {
                return BadRequest(ModelState);
            }
            var review = _rrep.GetReviews().Where(c => c.title.Trim().
            ToUpper() == reviewCreate.title.TrimEnd().ToUpper()).FirstOrDefault();


            if (review != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var rr = _mapper.Map<Review>(reviewCreate);
            rr.Pokemons = _poki.GetPokemon(pokemonid);
            rr.Reviewers = _rview.Reviewer(reviewerid);

          
            if (!_rrep.CreateReview(rr))
            {
                ModelState.AddModelError("", "Error while saving data");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");

        }

        [HttpPut("{rid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateCountry(int rid, [FromBody] ReviewDto cat)
        {
            if (cat == null)
            {
                return BadRequest(ModelState);
            }
            if (rid != cat.Id)
            { return BadRequest(ModelState); }

            if (!_rrep.ReviewExist(rid))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cm = _mapper.Map<Review>(cat);
            if (!_rrep.UpdateReview(cm))
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

        public IActionResult DeleteReview(int cid)
        {
            if (!_rview.ReviewExist(cid))
            {
                return NotFound();
            }
            var cd = _rview.Reviewer(cid);
            
            if (!_rview.DeleteReviewer(cd))
            {
                ModelState.AddModelError("", "someting went to wrong");
            }
            return NoContent();
        }
    }
}
