using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, SignalRContext>, IOrderDal
    {
        public async Task<decimal> TodayTotalPriceAsync()
        {
            using(var context = new SignalRContext())
            {
                return await context.Orders.
                    Where(o=>o.Date == DateTime.Today && o.Description == "Hesab bağlandı").SumAsync(o => o.TotalPrice);
            }
        }

        public async Task<decimal> TotalAmountAsync()
        {
            using(var context = new SignalRContext())
            {
                return await context.Orders.SumAsync(o => o.TotalPrice);
            }
        }

        public async Task<int> TotalOrderCountAsync()
        {
            using (var context = new SignalRContext())
            {
                return await context.Orders.CountAsync();
            }
        }
    }
}
