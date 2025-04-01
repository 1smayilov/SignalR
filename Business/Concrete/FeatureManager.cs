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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task<IResult> AddAsync(Feature entity)
        {
            await _featureDal.AddAsync(entity);
            return new SuccessResult(Messages.FeatureAdded);
        }

        public async Task<IResult> DeleteAsync(Feature entity)
        {
            await _featureDal.DeleteAsync(entity);
            return new SuccessResult(Messages.FeatureRemoved);
        }

        public async Task<IDataResult<List<Feature>>> GetAllAsync()
        {
            var result = await _featureDal.GetAllAsync();
            return new SuccessDataResult<List<Feature>>(result, Messages.FeaturesListed);
        }

        public async Task<IDataResult<Feature>> GetByIdAsync(int id)
        {
            var result = await _featureDal.GetAsync(a => a.FeatureId == id);
            return new SuccessDataResult<Feature>(result, Messages.FeatureFetchedById);
        }

        public async Task<IResult> UpdateAsync(Feature entity)
        {
            await _featureDal.UpdateAsync(entity);
            return new SuccessResult(Messages.FeatureUpdated);
        }
    }
}
