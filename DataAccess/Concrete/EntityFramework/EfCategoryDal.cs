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
    public class EfCategoryDal : EfEntityRepositoryBase<Category, SignalRContext>, ICategoryDal
    {
        public async Task<int> ActiveCategoryCountAsync()
        {
            using (var context = new SignalRContext())
            {
                return await context.Categories
                    .Where(c => c.Status == true)
                    .CountAsync();
            }
        }

        public async Task<int> CategoryCountAsync()
        {
            using (var context = new SignalRContext())
            {
                return await context.Categories.CountAsync();
            }
        }

        public async Task<int> PassiveCategoryCountAsync()
        {
            using (var context = new SignalRContext())
            {
                return await context.Categories
                    .Where(c => c.Status == false)
                    .CountAsync();
            }
        }

        public async Task<int> ProductCountByCategoryNameQəlyanaltılarAsync()
        {
            using (var context = new SignalRContext())
            {
                return await context.Products
                    .Where(p => p.Category.CategoryName == "Qəlyanaltılar")
                    .CountAsync();
            }
        }
    }
}
