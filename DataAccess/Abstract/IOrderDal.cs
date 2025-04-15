using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        Task<int> TotalOrderCountAsync();
        Task<decimal> TodayTotalPriceAsync();
        Task<decimal> TotalAmountAsync();
    }
}
