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
    public class FeatureDescriptionManager : IFeatureDescriptionService
    {
        private readonly IFeatureDescriptionDal _featureDescriptionDal;

        public FeatureDescriptionManager(IFeatureDescriptionDal featureDescriptionDal)
        {
            _featureDescriptionDal = featureDescriptionDal;
        }

        public async Task<IResult> AddAsync(FeatureDescription entity)
        {
            await _featureDescriptionDal.AddAsync(entity);
            return new SuccessResult(Messages.FeatureDescriptionAdded);
        }

        public async Task<IResult> DeleteAsync(FeatureDescription entity)
        {
            await _featureDescriptionDal.DeleteAsync(entity);
            return new SuccessResult(Messages.FeatureDescriptionRemoved);
        }

        public async Task<IDataResult<List<FeatureDescription>>> GetAllAsync()
        {
            var result = await _featureDescriptionDal.GetAllAsync();
            return new SuccessDataResult<List<FeatureDescription>>(result, Messages.FeatureDescriptionsListed);
        }

        public async Task<IDataResult<FeatureDescription>> GetByIdAsync(int id)
        {
            var result = await _featureDescriptionDal.GetAsync(a => a.FeatureDescriptionId == id);
            return new SuccessDataResult<FeatureDescription>(result, Messages.FeatureDescriptionFetchedById);
        }

        public async Task<IResult> UpdateAsync(FeatureDescription entity)
        {
            await _featureDescriptionDal.UpdateAsync(entity);
            return new SuccessResult(Messages.FeatureDescriptionUpdated);
        }
    }
}
