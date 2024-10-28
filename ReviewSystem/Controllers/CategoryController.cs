using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Dto.Get;
using ReviewSystem.Dto.Post;
using ReviewSystem.Models;

namespace ReviewSystem.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<List<Category>> GetCategorys()
		{
			var Categorys = _unitOfWork.Category.GetAll();
			var CategorysDto = _mapper.Map<List<CategoryDto>>(Categorys);
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(CategorysDto);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Category> GetCategory(int id)
		{
			if (id <= 0)
				return BadRequest();

			if (!_unitOfWork.Category.IsExist(id))
				return NotFound();

			var Category = _unitOfWork.Category.Get(x => x.Id == id);
			var CategoryDto = _mapper.Map<CategoryDto>(Category);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(CategoryDto);
		}

		[HttpGet("product/{categoryId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ProductDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetProductByCategory(int categoryId)
		{
			if (categoryId <= 0)
				return BadRequest();

			var products = _unitOfWork.Category.GetProductByCategory(categoryId);
			if (products == null)
				return NotFound();
			var productDto = _mapper.Map<List<ProductDto>>(products);

			if (!ModelState.IsValid)
				return BadRequest();
			
			return Ok(productDto);
		}

		[HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult AddCategory(CreateCategoryDto categoryDto) 
		{
			var category = new Category
			{
				Name = categoryDto.Name,
			};
			_unitOfWork.Category.Add(category);
			_unitOfWork.Save();
			return Ok(category);
		}

        [HttpPut("categoryId/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DeleteReview(CreateCategoryDto categoryDto ,int categoryId)
        {
            if (categoryDto == null || categoryId == 0)
                return BadRequest();

            var category = _unitOfWork.Category.Get(x => x.Id == categoryId);
            if (category == null)
                return NotFound();

            category.Name = categoryDto.Name;

            var result = _unitOfWork.Save();
            if (!result)
                return BadRequest("Error while saving");

            return Ok();
        }

        [HttpDelete("categoryId/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DeleteReview(int categoryId)
        {
            if (categoryId == 0)
                return BadRequest();

            var ctegory = _unitOfWork.Category.Get(x => x.Id == categoryId);
            if (ctegory == null)
                return NotFound();

            _unitOfWork.Category.Remove(ctegory);

            var result = _unitOfWork.Save();
            if (!result)
                return BadRequest("Error while saving");

            return Ok();
        }

    }
}
