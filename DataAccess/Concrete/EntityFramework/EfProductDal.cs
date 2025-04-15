using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;
using Entity.DTOs.ProductDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SignalRContext>, IProductDal
    {
        

        public async Task<List<ResultProductWithCategory>> GetAllProductsWithCategories()
        {
            using (var context = new SignalRContext())
            {
                var result = await context.Products.Include(p => p.Category)
                    .Select(p => new ResultProductWithCategory
                    {
                        CategoryName = p.Category.CategoryName,
                        Description = p.Description,
                        ImageUrl = p.ImageUrl,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        ProductId = p.ProductId,
                        Status = p.Status
                    }).ToListAsync();
                return result;
            } 
        }

        public async Task<int> ProductCountAsync()
        {
            using(var context = new SignalRContext())
            {
                return await context.Products.CountAsync();
            }
        }

        public async Task<string> ProductNameByMaxPriceAsync()
        {
            using(var context = new SignalRContext())
            {
                var result = await context.Products
                    .OrderByDescending(p=>p.Price)
                    .Select(p=>p.ProductName)
                    .FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<string> ProductNameByMinPriceAsync()
        {
            using (var context = new SignalRContext())
            {
                var result = await context.Products
                    .OrderBy(context => context.Price)
                    .Select(p => p.ProductName)
                    .FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<decimal> ProductPriceAvgAsync()
        {
            using(var context = new SignalRContext())
            {
                return await context.Products.AverageAsync(p => p.Price);
            }
        }

        public async Task<decimal> ProductPriceAvgByBurgerAsync()
        {
            using(var context = new SignalRContext())
            {
                return await context.Products
                    .Where(p => p.Category.CategoryName == "Burgerlər")
                    .AverageAsync(p => p.Price);
            }
        }
    }
}
