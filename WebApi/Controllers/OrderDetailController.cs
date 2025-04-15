using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.OrderDetailDto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }


        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var serviceResult = await _orderDetailService.GetAllAsync();
            var mapResult = _mapper.Map<List<ResultOrderDetailDto>>(serviceResult.Data);
            var dataResult = new DataResult<List<ResultOrderDetailDto>>(mapResult, serviceResult.Success, serviceResult.Message);
            return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var serviceResult = await _orderDetailService.GetByIdAsync(id);
            var mapResult = _mapper.Map<GetByIdOrderDetailDto>(serviceResult.Data);
            var dataResult = new DataResult<GetByIdOrderDetailDto>(mapResult, serviceResult.Success, serviceResult.Message);
            return serviceResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateOrderDetailDto createOrderDetailDto)
        {
            var data = _mapper.Map<OrderDetail>(createOrderDetailDto);
            var result = await _orderDetailService.AddAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateOrderDetailDto updateOrderDetailDto)
        {
            var data = _mapper.Map<OrderDetail>(updateOrderDetailDto);
            var result = await _orderDetailService.UpdateAsync(data);
            return result.Success ? Ok(result) : BadRequest(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _orderDetailService.GetByIdAsync(id);
            var result = await _orderDetailService.DeleteAsync(data.Data);
            return result.Success ? Ok(result) : BadRequest(result);

        }
    }
}
