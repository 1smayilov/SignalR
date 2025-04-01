using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CategoryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet("Getall")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _categoryService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultCategoryDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultCategoryDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _categoryService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdCategoryDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdCategoryDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateCategoryDto createCategoryDto)
		{
			var data = _mapper.Map<Category>(createCategoryDto);
			var result = await _categoryService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateCategoryDto updateCategoryDto)
		{
			var data = _mapper.Map<Category>(updateCategoryDto);
			var result = await _categoryService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _categoryService.GetByIdAsync(id);
			var result = await _categoryService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
