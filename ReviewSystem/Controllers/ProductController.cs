using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Dto;
using ReviewSystem.Models;
using System.Collections.Generic;

namespace ReviewSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<List<Product>> GetProducts()
		{
			var products = _unitOfWork.Product.GetAll();
			var productsDto = _mapper.Map<List<ProductDto>>(products);
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(productsDto);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Product> GetProduct(int id)
		{
			if (id <= 0)
				return BadRequest();

			if (!_unitOfWork.Product.IsExist(id))
				return NotFound();

			var product = _unitOfWork.Product.Get(x => x.Id == id);
			var productDto = _mapper.Map<ProductDto>(product);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(productDto);
		}

		[HttpGet("productId/rating")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetProductRating(int id)
		{
			if (id <= 0)
				return BadRequest();

			if (!_unitOfWork.Product.IsExist(id))
				return NotFound();

			var rating = _unitOfWork.Product.GetProductRating(id);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(rating);
		}
	}
}
