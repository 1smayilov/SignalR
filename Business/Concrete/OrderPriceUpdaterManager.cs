using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderPriceUpdaterManager : IOrderPriceUpdaterService
    {
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IOrderDal _orderDal;
        public OrderPriceUpdaterManager(IOrderDetailDal orderDetailDal, IOrderDal orderDal)
        {
            _orderDetailDal = orderDetailDal;
            _orderDal = orderDal;
        }

        public async Task UpdateOrderTotalPriceAsync(int orderId)
        {
            var orderDetails = await _orderDetailDal.GetAllAsync(od => od.OrderId == orderId);
            var totalPrice = orderDetails.Sum(od => od.TotalPrice);
            var order = await _orderDal.GetAsync(o => o.OrderId == orderId);
            if(order != null)
            {
                order.TotalPrice = totalPrice;
                await _orderDal.UpdateAsync(order);
            }
            else
            {
                throw new Exception("Order not found");
            }
        }
    }
}
