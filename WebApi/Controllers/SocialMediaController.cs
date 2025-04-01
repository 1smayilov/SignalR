using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.SocialMediaDto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _socialMediaService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultSocialMediaDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultSocialMediaDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _socialMediaService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdSocialMediaDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdSocialMediaDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateSocialMediaDto createSocialMediaDto)
		{
			var data = _mapper.Map<SocialMedia>(createSocialMediaDto);
			var result = await _socialMediaService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var data = _mapper.Map<SocialMedia>(updateSocialMediaDto);
			var result = await _socialMediaService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _socialMediaService.GetByIdAsync(id);
			var result = await _socialMediaService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
