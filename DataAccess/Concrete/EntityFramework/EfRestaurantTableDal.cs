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
    public class EfRestaurantTableDal : EfEntityRepositoryBase<RestaurantTable, SignalRContext>, IRestaurantTableDal
    {
        public async Task<int> RestaurantTableCountAsync()
        {
            using(var context = new SignalRContext())
            {
                return await context.RestaurantTables.CountAsync();
            }
        }
    }
}
