﻿using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Task<IDataResult<List<ResultProductWithCategory>>> GetAllProductsWithCategories();
        Task<IDataResult<int>> ProductCountAsync();
        Task<IDataResult<decimal>> ProductPriceAvgAsync();
        Task<IDataResult<string>> ProductNameByMaxPriceAsync();
        Task<IDataResult<string>> ProductNameByMinPriceAsync();
        Task<IDataResult<decimal>> ProductPriceAvgByBurgerAsync();


    }
}
