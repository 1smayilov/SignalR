using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.TestimonialDto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _testimonialService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultTestimonialDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultTestimonialDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _testimonialService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdTestimonialDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdTestimonialDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateTestimonialDto createTestimonialDto)
		{
			var data = _mapper.Map<Testimonial>(createTestimonialDto);
			var result = await _testimonialService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateTestimonialDto updateTestimonialDto)
		{
			var data = _mapper.Map<Testimonial>(updateTestimonialDto);
			var result = await _testimonialService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _testimonialService.GetByIdAsync(id);
			var result = await _testimonialService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
