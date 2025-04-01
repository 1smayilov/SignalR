using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.DiscountDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _discountService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultDiscountDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultDiscountDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpGet("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _discountService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdDiscountDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdDiscountDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateDiscountDto updateDiscountDto)
		{
			var data = _mapper.Map<Discount>(updateDiscountDto);
			var result = await _discountService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateDiscountDto createDiscountDto)
		{
			var data = _mapper.Map<Discount>(createDiscountDto);
			var result = await _discountService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _discountService.GetByIdAsync(id);
			var result = await _discountService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
