using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<IResult> AddAsync(Product entity)
        {
            await _productDal.AddAsync(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Product entity)
        {
            await _productDal.DeleteAsync(entity);
            return new SuccessResult(Messages.ProductRemoved);
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            var result = await _productDal.GetAllAsync();
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public async Task<IDataResult<List<ResultProductWithCategory>>> GetAllProductsWithCategories()
        {
            var result = await _productDal.GetAllProductsWithCategories();
            return new SuccessDataResult<List<ResultProductWithCategory>>(result, Messages.ProductsWithCategoryListed);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var result = await _productDal.GetAsync(a => a.ProductId == id);
            return new SuccessDataResult<Product>(result, Messages.ProductFetchedById);
        }

        public async Task<IResult> UpdateAsync(Product entity)
        {
            await _productDal.UpdateAsync(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
