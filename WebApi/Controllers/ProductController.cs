using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.ProductDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _productService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultProductDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultProductDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _productService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdProductDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdProductDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("GetProductListWithCategory")]
		public async Task<IActionResult> GetProductListWithCategoryAsync()
		{
			var serviceResult = await _productService.GetAllProductsWithCategories();
			var mapResult = _mapper.Map<List<ResultProductWithCategory>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultProductWithCategory>>(mapResult,serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpGet("ProductCount")]
		public async Task<IActionResult> ProductCountAsync()
		{
			var result = await _productService.ProductCountAsync();
			return result.Success ? Ok(result) : BadRequest(result);
        }

		[HttpGet("ProductPriceAvg")]
        public async Task<IActionResult> ProductPriceAvgAsync()
        {
            var result = await _productService.ProductPriceAvgAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("ProductNameByMaxPrice")]
        public async Task<IActionResult> ProductNameByMaxPriceAsync()
        {
            var result = await _productService.ProductNameByMaxPriceAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("ProductNameByMinPrice")]
        public async Task<IActionResult> ProductNameByMinPriceAsync()
        {
            var result = await _productService.ProductNameByMinPriceAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

		[HttpGet("ProductPriceAvgByBurger")]
		public async Task<IActionResult> ProductPriceAvgByBurgerAsync()
		{
            var result = await _productService.ProductPriceAvgByBurgerAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
		public async Task<IActionResult> AddAsync(CreateProductDto createProductDto)
		{
			var data = _mapper.Map<Product>(createProductDto);
			var result = await _productService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateProductDto updateProductDto)
		{
			var data = _mapper.Map<Product>(updateProductDto);
			var result = await _productService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _productService.GetByIdAsync(id);
			var result = await _productService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
