using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.FeatureDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IFeatureService _featureService;
		private readonly IMapper _mapper;

		public FeatureController(IFeatureService featureService, IMapper mapper)
		{
			_featureService = featureService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _featureService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultFeatureDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultFeatureDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpGet("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _featureService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdFeatureDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdFeatureDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateFeatureDto createFeatureDto)
		{
			var data = _mapper.Map<Feature>(createFeatureDto);
			var result = await _featureService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateFeatureDto updateFeatureDto)
		{
			var data = _mapper.Map<Feature>(updateFeatureDto);
			var result = await _featureService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _featureService.GetByIdAsync(id);
			var result = await _featureService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
