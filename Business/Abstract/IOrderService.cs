using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<IDataResult<int>> TotalOrderCountAsync();
        Task<IDataResult<decimal>> TodayTotalPriceAsync();
        Task<IDataResult<decimal>> TotalAmountAsync();

    }
}
