using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Dto;
using ReviewSystem.Models;

namespace ReviewSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewerController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ReviewerController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<List<Reviewer>> GetReviewers()
		{
			var Reviewers = _unitOfWork.Reviewer.GetAll();
			var ReviewersDto = _mapper.Map<List<ReviewerDto>>(Reviewers);
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(ReviewersDto);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Reviewer> GetReviewer(int id)
		{
			if (id <= 0)
				return BadRequest();

			if (!_unitOfWork.Reviewer.IsExist(id))
				return NotFound();

			var Reviewer = _unitOfWork.Reviewer.Get(x => x.Id == id);
			var ReviewerDto = _mapper.Map<ReviewerDto>(Reviewer);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(ReviewerDto);
		}

		[HttpGet("reviewer/{reviewerId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewerDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetReviewerReview(int reviewerId)
		{
			if (reviewerId <= 0)
				return BadRequest();

			var reviews = _unitOfWork.Review.GetProductReviews(reviewerId);
			if (reviews == null)
				return NotFound();
			var reviewsDto = _mapper.Map<List<ReviewDto>>(reviews);

			if (!ModelState.IsValid)
				return BadRequest();

			return Ok(reviewsDto);
		}
	}
}
