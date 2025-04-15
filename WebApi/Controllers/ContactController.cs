using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.ContactDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet("Getall")]
		public async Task<IActionResult> GetAllAsync()
		{
			var serviceResult = await _contactService.GetAllAsync();
			var mapResult = _mapper.Map<List<ResultContactDto>>(serviceResult.Data);
			var dataResult = new DataResult<List<ResultContactDto>>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var serviceResult = await _contactService.GetByIdAsync(id);
			var mapResult = _mapper.Map<GetByIdContactDto>(serviceResult.Data);
			var dataResult = new DataResult<GetByIdContactDto>(mapResult, serviceResult.Success, serviceResult.Message);
			return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateContactDto createContactDto)
		{
			var data = _mapper.Map<Contact>(createContactDto);
			var result = await _contactService.AddAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateContactDto updateContactDto)
		{
			var data = _mapper.Map<Contact>(updateContactDto);
			var result = await _contactService.UpdateAsync(data);
			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var data = await _contactService.GetByIdAsync(id);
			var result = await _contactService.DeleteAsync(data.Data);
			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
