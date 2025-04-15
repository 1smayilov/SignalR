using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.BookingDto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		private readonly IMapper _mapper;

		public BookingController(IBookingService bookingService, IMapper mapper)
		{
			_bookingService = bookingService;
			_mapper = mapper;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _bookingService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultBookingDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultBookingDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _bookingService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdBookingDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdBookingDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateBookingDto createBookingDto)
		{
			var data = _mapper.Map<Booking>(createBookingDto);
			var result = await _bookingService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateBookingDto updateBookingDto)
		{
			var data = _mapper.Map<Booking>(updateBookingDto);
			var result = await _bookingService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _bookingService.GetByIdAsync(id);
			var result = await _bookingService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
