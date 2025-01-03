﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Dto.Get;
using ReviewSystem.Models;

namespace ReviewSystem.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class SellerController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SellerController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<List<Seller>> GetSellers()
		{
			var Sellers = _unitOfWork.Seller.GetAll();
			var SellersDto = _mapper.Map<List<SellerDto>>(Sellers);
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(SellersDto);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Seller> GetSeller(int id)
		{
			if (id <= 0)
				return BadRequest();

			if (!_unitOfWork.Seller.IsExist(id))
				return NotFound();

			var Seller = _unitOfWork.Seller.Get(x => x.Id == id);
			var SellerDto = _mapper.Map<SellerDto>(Seller);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(SellerDto);
		}

		[HttpGet("product/{sellerId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ProductDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetProductBySeller(int sellerId)
		{
			if (sellerId <= 0)
				return BadRequest();

			var products = _unitOfWork.Seller.GetProductBySeller(sellerId);
			if (products == null)
				return NotFound();
			var productDto = _mapper.Map<List<ProductDto>>(products);

			if (!ModelState.IsValid)
				return BadRequest();

			return Ok(productDto);
		}

		[HttpGet("seller/{productId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<SellerDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetProductSeller(int productId)
		{
			if (productId <= 0)
				return BadRequest();

			var Sellers = _unitOfWork.Seller.GetProductSeller(productId);
			if (Sellers == null)
				return NotFound();
			var SellersDto = _mapper.Map<List<SellerDto>>(Sellers);

			if (!ModelState.IsValid)
				return BadRequest();

			return Ok(SellersDto);
		}

        [HttpDelete("sellerId/{sellerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DeleteReview(int sellerId)
        {
            if (sellerId == 0)
                return BadRequest();

            var seller = _unitOfWork.Seller.Get(x => x.Id == sellerId);
            if (seller == null)
                return NotFound();

            _unitOfWork.Seller.Remove(seller);

            var result = _unitOfWork.Save();
            if (!result)
                return BadRequest("Error while saving");

            return Ok();
        }
    }
}
