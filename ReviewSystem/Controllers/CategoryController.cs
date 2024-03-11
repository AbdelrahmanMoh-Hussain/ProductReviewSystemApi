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

		[HttpGet("pokemon/{categoryId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ProductDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetPokemonByCategory(int categoryId)
		{
			if (categoryId <= 0)
				return BadRequest();

			var pokemons = _unitOfWork.Category.GetPokemonByCategory(categoryId);
			if (pokemons == null)
				return NotFound();
			var pokemonDto = _mapper.Map<List<ProductDto>>(pokemons);

			if (!ModelState.IsValid)
				return BadRequest();
			
			return Ok(pokemonDto);
		}
	}
}
