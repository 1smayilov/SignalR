using AutoMapper;
using AutoMapper.Configuration;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.AboutDto;
using Entity.DTOs.BookingDto;
using Entity.DTOs.OpeningHourDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }


        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var serviceResult = await _aboutService.GetAllAsync();
            var mapResult = _mapper.Map<List<ResultAboutDto>>(serviceResult.Data);
            var dataResult = new DataResult<List<ResultAboutDto>>(mapResult, serviceResult.Success, serviceResult.Message);
            return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var serviceResult = await _aboutService.GetByIdAsync(id);
            var mapResult = _mapper.Map<GetByIdAboutDto>(serviceResult.Data);
            var dataResult = new DataResult<GetByIdAboutDto>(mapResult, serviceResult.Success, serviceResult.Message);
            return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }


        [HttpPost]  
        public async Task<IActionResult> AddAsync(CreateAboutDto createAboutDto)
        {
            var data = _mapper.Map<About>(createAboutDto);
            var result = await _aboutService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var data = _mapper.Map<About>(updateAboutDto);
            var result = await _aboutService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);

		}


		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _aboutService.GetByIdAsync(id);
            var result = await _aboutService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);

		}
	}
}
