using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Dto.Get;
using ReviewSystem.Dto.Post;
using ReviewSystem.Dto.Put;
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
			var Reviews = _unitOfWork.Review.GetAll("Product");
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

			var Review = _unitOfWork.Review.Get(x => x.Id == id, "Product");
			var ReviewDto = _mapper.Map<ReviewDto>(Review);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(ReviewDto);
		}

		[HttpGet("product/{productId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetProductIdReview(int productId)
		{
			if (productId <= 0)
				return BadRequest();

			var reviews = _unitOfWork.Review.GetProductReviews(productId);
			if (reviews == null)
				return NotFound();
			var reviewsDto = _mapper.Map<List<ReviewDto>>(reviews);

			if (!ModelState.IsValid)
				return BadRequest();

			return Ok(reviewsDto);
		}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult AddReview(CreateReviewDto reviewDto)
        {
			if(!_unitOfWork.Product.IsExist(reviewDto.ProductId)
				|| !_unitOfWork.Reviewer.IsExist(reviewDto.ReviewerId))
				return BadRequest();

			var review = new Review
			{
				Title = reviewDto.Title,
				Text = reviewDto.Text,
				Rating = reviewDto.Rating,
				ProdcutId = reviewDto.ProductId,
				ReviewerId = reviewDto.ReviewerId,
			};

            _unitOfWork.Review.Add(review);
            _unitOfWork.Save();
            return Ok(review);
        }

        [HttpPut("reviewId/{reviewId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult UpdateReview(UpdateReviewDto reviewDto, int reviewId)
        {
			if(reviewDto is null || reviewId == 0)
				return BadRequest();

            var review = _unitOfWork.Review.Get(x => x.Id == reviewId);
			if(review == null) 
				return NotFound();

			review.Title = reviewDto.Title;
			review.Text = reviewDto.Text;
			review.Rating = reviewDto.Rating;
			var result = _unitOfWork.Save();
			if (!result)
				return BadRequest("Error while saving");


			return Ok();
        }

        [HttpDelete("reviewId/{reviewId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DeleteReview(int reviewId)
        {
            if ( reviewId == 0)
                return BadRequest();

            var review = _unitOfWork.Review.Get(x => x.Id == reviewId);
            if (review == null)
                return NotFound();
			
			_unitOfWork.Review.Remove(review);

            var result = _unitOfWork.Save();
            if (!result)
                return BadRequest("Error while saving");

            return Ok();
        }


    }
}
