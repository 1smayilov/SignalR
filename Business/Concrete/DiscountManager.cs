using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public async Task<IResult> AddAsync(Discount entity)
        {
            await _discountDal.AddAsync(entity);
            return new SuccessResult(Messages.DiscountAdded);
        }

        public async Task<IResult> DeleteAsync(Discount entity)
        {
            await _discountDal.DeleteAsync(entity);
            return new SuccessResult(Messages.DiscountRemoved);
        }

        public async Task<IDataResult<List<Discount>>> GetAllAsync()
        {
            var result = await _discountDal.GetAllAsync();
            return new SuccessDataResult<List<Discount>>(result, Messages.DiscountsListed);
        }

        public async Task<IDataResult<Discount>> GetByIdAsync(int id)
        {
            var result = await _discountDal.GetAsync(a => a.DiscountId == id);
            return new SuccessDataResult<Discount>(result, Messages.DiscountFetchedById);
        }

        public async Task<IResult> UpdateAsync(Discount entity)
        {
            await _discountDal.UpdateAsync(entity);
            return new SuccessResult(Messages.DiscountUpdated);
        }
    }
}
