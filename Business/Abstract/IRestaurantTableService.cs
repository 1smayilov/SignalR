﻿using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRestaurantTableService : IGenericService<RestaurantTable>
    {
        Task<IDataResult<int>> RestaurantTableCountAsync();
    }
}
