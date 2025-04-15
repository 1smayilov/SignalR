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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<IResult> AddAsync(Order entity)
        {
            await _orderDal.AddAsync(entity);
            return new SuccessResult(Messages.OrderAdded);
        }

        public async Task<IResult> DeleteAsync(Order entity)
        {
            await _orderDal.DeleteAsync(entity);
            return new SuccessResult(Messages.OrderRemoved);
        }

        public async Task<IDataResult<List<Order>>> GetAllAsync()
        {
            var result = await _orderDal.GetAllAsync();
            return new SuccessDataResult<List<Order>>(result, Messages.OrdersListed);
        }

        public async Task<IDataResult<Order>> GetByIdAsync(int id)
        {
            var result = await _orderDal.GetAsync(a => a.OrderId == id);
            return new SuccessDataResult<Order>(result, Messages.OrderFetchedById);
        }

        public async Task<IDataResult<decimal>> TodayTotalPriceAsync()
        {
            return new SuccessDataResult<decimal>(await _orderDal.TodayTotalPriceAsync(), Messages.TodayTotalPriceFetched);
        }

        public async Task<IDataResult<decimal>> TotalAmountAsync()
        {
            return new SuccessDataResult<decimal>(await _orderDal.TotalAmountAsync(), Messages.TotalAmountFetched);
        }

        public async Task<IDataResult<int>> TotalOrderCountAsync()
        {
            return new SuccessDataResult<int>(await _orderDal.TotalOrderCountAsync(), Messages.TotalOrderCountFetched);
        }

        public async Task<IResult> UpdateAsync(Order entity)
        {
            await _orderDal.UpdateAsync(entity);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
