using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.RestaurantTableDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IRestaurantTableService _restaurantTableService;
        private readonly IMapper _mapper;

        public RestaurantTableController(IRestaurantTableService restaurantTableService, IMapper mapper)
        {
            _restaurantTableService = restaurantTableService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var serviceResult = await _restaurantTableService.GetAllAsync();
            var mapResult = _mapper.Map<List<ResultRestaurantTableDto>>(serviceResult.Data);
            var dataResult = new DataResult<List<ResultRestaurantTableDto>>(mapResult, serviceResult.Success, serviceResult.Message);
            return dataResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }

        [HttpGet("RestaurantTableCount")]
        public async Task<IActionResult> RestaurantTableCountAsync()
        {
            var result = await _restaurantTableService.RestaurantTableCountAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var serviceResult = await _restaurantTableService.GetByIdAsync(id);
            var mapResult = _mapper.Map<GetByIdRestaurantTableDto>(serviceResult.Data);
            var dataResult = new DataResult<GetByIdRestaurantTableDto>(mapResult, serviceResult.Success, serviceResult.Message);
            return dataResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateRestaurantTableDto createRestaurantTableDto)
        {
            var data = _mapper.Map<RestaurantTable>(createRestaurantTableDto);
            var result = await _restaurantTableService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateRestaurantTableDto updateRestaurantTableDto)
        {
            var data = _mapper.Map<RestaurantTable>(updateRestaurantTableDto);
            var result = await _restaurantTableService.UpdateAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var serviceResult = await _restaurantTableService.GetByIdAsync(id);
            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult);
            }
            var result = await _restaurantTableService.DeleteAsync(serviceResult.Data);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
