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
    public class FeatureDetailManager : IFeatureDetailService
    {
        private readonly IFeatureDetailDal _FeatureDetailDal;

        public FeatureDetailManager(IFeatureDetailDal FeatureDetailDal)
        {
            _FeatureDetailDal = FeatureDetailDal;
        }

        public async Task<IResult> AddAsync(FeatureDetail entity)
        {
            await _FeatureDetailDal.AddAsync(entity);
            return new SuccessResult(Messages.FeatureDetailAdded);
        }

        public async Task<IResult> DeleteAsync(FeatureDetail entity)
        {
            await _FeatureDetailDal.DeleteAsync(entity);
            return new SuccessResult(Messages.FeatureDetailRemoved);
        }

        public async Task<IDataResult<List<FeatureDetail>>> GetAllAsync()
        {
            var result = await _FeatureDetailDal.GetAllAsync();
            return new SuccessDataResult<List<FeatureDetail>>(result, Messages.FeatureDetailsListed);
        }

        public async Task<IDataResult<FeatureDetail>> GetByIdAsync(int id)
        {
            var result = await _FeatureDetailDal.GetAsync(a => a.FeatureDetailId == id);
            return new SuccessDataResult<FeatureDetail>(result, Messages.FeatureDetailFetchedById);
        }

        public async Task<IResult> UpdateAsync(FeatureDetail entity)
        {
            await _FeatureDetailDal.UpdateAsync(entity);
            return new SuccessResult(Messages.FeatureDetailUpdated);
        }
    }
}
