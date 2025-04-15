using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.OrderDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var serviceResult = await _orderService.GetAllAsync();
            var mapResult = _mapper.Map<List<ResultOrderDto>>(serviceResult.Data);
            var dataResult = new DataResult<List<ResultOrderDto>>(mapResult, serviceResult.Success, serviceResult.Message);
            return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var serviceResult = await _orderService.GetByIdAsync(id);
            var mapResult = _mapper.Map<GetByIdOrderDto>(serviceResult.Data);
            var dataResult = new DataResult<GetByIdOrderDto>(mapResult, serviceResult.Success, serviceResult.Message);
            return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }

        [HttpGet("TotalOrderCount")]
        public async Task<IActionResult> TotalOrderCountAsync()
        {
            var result = await _orderService.TotalOrderCountAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("TotalOrderPrice")]
        public async Task<IActionResult> TodayTotalPriceAsync()
        {
            var result = await _orderService.TodayTotalPriceAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("TotalAmount")]
        public async Task<IActionResult> TotalAmountAsync()
        {
            var result = await _orderService.TotalAmountAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateOrderDto createOrderDto)
        {
            var data = _mapper.Map<Order>(createOrderDto);
            var result = await _orderService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateOrderDto updateOrderDto)
        {
            var data = _mapper.Map<Order>(updateOrderDto);
            var result = await _orderService.UpdateAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _orderService.GetByIdAsync(id);
            var result = await _orderService.DeleteAsync(data.Data);
            return result.Success ? Ok(result) : BadRequest(result);

        }
    }
}
