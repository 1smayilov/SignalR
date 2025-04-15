using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IOrderPriceUpdaterService _orderPriceUpdaterService;

        public OrderDetailManager(IOrderDetailDal orderDetailDal, IOrderPriceUpdaterService orderPriceUpdaterService)
        {
            _orderDetailDal = orderDetailDal;
            _orderPriceUpdaterService = orderPriceUpdaterService;
        }

        public async Task<IResult> AddAsync(OrderDetail entity)
        {
            await _orderDetailDal.AddAsync(entity);
            await _orderPriceUpdaterService.UpdateOrderTotalPriceAsync(entity.OrderId);
            return new SuccessResult(Messages.OrderDetailAdded);
        }

        public async Task<IResult> DeleteAsync(OrderDetail entity)
        {
            await _orderDetailDal.DeleteAsync(entity);
            await _orderPriceUpdaterService.UpdateOrderTotalPriceAsync(entity.OrderId);
            return new SuccessResult(Messages.OrderDetailRemoved);
        }

        public async Task<IDataResult<List<OrderDetail>>> GetAllAsync()
        {
            var result = await _orderDetailDal.GetAllAsync();
            return new SuccessDataResult<List<OrderDetail>>(result, Messages.OrderDetailsListed);
        }

        public async Task<IDataResult<OrderDetail>> GetByIdAsync(int id)
        {
            var result = await _orderDetailDal.GetAsync(a => a.OrderDetailId == id);
            return new SuccessDataResult<OrderDetail>(result, Messages.OrderDetailFetchedById);
        }

        public async Task<IResult> UpdateAsync(OrderDetail entity)
        {
            await _orderDetailDal.UpdateAsync(entity);
            await _orderPriceUpdaterService.UpdateOrderTotalPriceAsync(entity.OrderId);
            return new SuccessResult(Messages.OrderDetailUpdated);
        }
    }
}
