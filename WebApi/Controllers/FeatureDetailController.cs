using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.FeatureDetailDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureDetailController : ControllerBase
	{
		private readonly IFeatureDetailService _FeatureDetailService;
		private readonly IMapper _mapper;

		public FeatureDetailController(IFeatureDetailService FeatureDetailService, IMapper mapper)
		{
			_FeatureDetailService = FeatureDetailService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _FeatureDetailService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultFeatureDetailDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultFeatureDetailDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _FeatureDetailService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdFeatureDetailDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdFeatureDetailDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateFeatureDetailDto createFeatureDetailDto)
		{
			var data = _mapper.Map<FeatureDetail>(createFeatureDetailDto);
			var result = await _FeatureDetailService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateFeatureDetailDto updateFeatureDetailDto)
		{
			var data = _mapper.Map<FeatureDetail>(updateFeatureDetailDto);
			var result = await _FeatureDetailService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _FeatureDetailService.GetByIdAsync(id);
			var result = await _FeatureDetailService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
