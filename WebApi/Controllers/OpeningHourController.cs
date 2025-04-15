using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.OpeningHourDto;
using Entity.DTOs.OpeningHoursDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OpeningHourController : ControllerBase
	{
		private readonly IOpeningHourService _openingHourService;
		private readonly IMapper _mapper;

		public OpeningHourController(IOpeningHourService openingHourService, IMapper mapper)
		{
			_openingHourService = openingHourService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _openingHourService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultOpeningHourDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultOpeningHourDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _openingHourService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdOpeningHourDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdOpeningHourDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateOpeningHourDto createOpeningHourDto)
		{
			var data = _mapper.Map<OpeningHours>(createOpeningHourDto);
			var result = await _openingHourService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateOpeningHourDto updateOpeningHourDto)
		{
			var data = _mapper.Map<OpeningHours>(updateOpeningHourDto);
			var result = await _openingHourService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _openingHourService.GetByIdAsync(id);
			var result = await _openingHourService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
