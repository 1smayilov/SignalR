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
    }
}
