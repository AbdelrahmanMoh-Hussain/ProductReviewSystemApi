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
	public class ReviewController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ReviewController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<List<Review>> GetReviews()
		{
			var Reviews = _unitOfWork.Review.GetAll();
			var ReviewsDto = _mapper.Map<List<ReviewDto>>(Reviews);
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(ReviewsDto);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Review> GetReview(int id)
		{
			if (id <= 0)
				return BadRequest();

			if (!_unitOfWork.Review.IsExist(id))
				return NotFound();

			var Review = _unitOfWork.Review.Get(x => x.Id == id);
			var ReviewDto = _mapper.Map<ReviewDto>(Review);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(ReviewDto);
		}

		[HttpGet("pokemon/{pokemonId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetPokemonReview(int pokemonId)
		{
			if (pokemonId <= 0)
				return BadRequest();

			var reviews = _unitOfWork.Review.GetProductReviews(pokemonId);
			if (reviews == null)
				return NotFound();
			var reviewsDto = _mapper.Map<List<ReviewDto>>(reviews);

			if (!ModelState.IsValid)
				return BadRequest();

			return Ok(reviewsDto);
		}
	}
}
