using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<List<ResultProductWithCategory>> GetAllProductsWithCategories();
        Task<int> ProductCountAsync();
        Task<decimal> ProductPriceAvgAsync();
        Task<string> ProductNameByMaxPriceAsync();
        Task<string> ProductNameByMinPriceAsync();
        Task<decimal> ProductPriceAvgByBurgerAsync();
    }
}
