using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_REL2.Dto;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReviewerController:Controller
    {
        private readonly IReviewerRepository _irrep;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository irrep,IMapper mapper)
        {
            _irrep=irrep;
            _mapper=mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        public IActionResult reviewers()
        {

            var own = _mapper.Map<List<ReviewerDto>>(_irrep.reviewers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(own);
        }

        [HttpGet("{oid}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult Reviewer(int oid)
        {
            if (_irrep.Reviewer(oid)==null)
            {
                return NotFound();
            }
            var own = _irrep.Reviewer(oid);

          
            return Ok(own);
        }

        [HttpGet("{rid}/Review")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewByViewer(int rid)
        {
            if (!_irrep.ReviewExist(rid))
            {
                return NotFound();
            }

            var owner = _mapper.Map<List<OwnerDto>>(
                _irrep.GetReviewByViewer(rid)
                );
            return Ok(owner);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReviewer([FromBody] ReviewerDto rviewer)
        {
            if (rviewer == null)
            {
                return BadRequest(ModelState);
            }
            var rv = _irrep.reviewers().Where(c => c.Firstname.Trim().
            ToUpper() == rviewer.Firstname.TrimEnd().ToUpper()).FirstOrDefault();

            if (rv != null)
            {
                ModelState.AddModelError("", "Reviewr already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var rvm = _mapper.Map<Reviewer>(rviewer);

            if (!_irrep.CreateReviewer(rvm))
            {
                ModelState.AddModelError("", "Error while saving data");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");

        }

        [HttpPut("{rvid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateReviewer(int rvid, [FromBody] ReviewerDto cat)
        {
            if (cat == null)
            {
                return BadRequest(ModelState);
            }
            if (rvid != cat.Id)
            { return BadRequest(ModelState); }

            if (!_irrep.ReviewExist(rvid))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cm = _mapper.Map<Reviewer>(cat);
            if (!_irrep.UpdateReviewer(cm))
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

        public IActionResult DeleteReviewer(int cid)
        {
            if (!_irrep.ReviewExist(cid))
            {
                return NotFound();
            }
            var cd = _irrep.Reviewer(cid);
            
            if (!_irrep.DeleteReviewer(cd))
            {
                ModelState.AddModelError("", "someting went to wrong");
            }
            return NoContent();
        }
    }
}
