using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.FeatureDescriptionDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureDescriptionController : ControllerBase
	{
		private readonly IFeatureDescriptionService _featureDescriptionService;
		private readonly IMapper _mapper;

		public FeatureDescriptionController(IFeatureDescriptionService featureDescriptionService, IMapper mapper)
		{
			_featureDescriptionService = featureDescriptionService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _featureDescriptionService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultFeatureDescriptionDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultFeatureDescriptionDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpGet("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _featureDescriptionService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdFeatureDescriptionDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdFeatureDescriptionDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(serviceResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateFeatureDescriptionDto createFeatureDescriptionDto)
		{
			var data = _mapper.Map<FeatureDescription>(createFeatureDescriptionDto);
			var result = await _featureDescriptionService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateFeatureDescriptionDto updateFeatureDescriptionDto)
		{
			var data = _mapper.Map<FeatureDescription>(updateFeatureDescriptionDto);
			var result = await _featureDescriptionService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _featureDescriptionService.GetByIdAsync(id);
			var result = await _featureDescriptionService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
