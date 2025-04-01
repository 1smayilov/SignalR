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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public async Task<IResult> AddAsync(SocialMedia entity)
        {
            await _socialMediaDal.AddAsync(entity);
            return new SuccessResult(Messages.SocialMediaAdded);
        }

        public async Task<IResult> DeleteAsync(SocialMedia entity)
        {
            await _socialMediaDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SocialMediaRemoved);
        }

        public async Task<IDataResult<List<SocialMedia>>> GetAllAsync()
        {
            var result = await _socialMediaDal.GetAllAsync();
            return new SuccessDataResult<List<SocialMedia>>(result, Messages.SocialMediasListed);
        }

        public async Task<IDataResult<SocialMedia>> GetByIdAsync(int id)
        {
            var result = await _socialMediaDal.GetAsync(a => a.SocialMediaId == id);
            return new SuccessDataResult<SocialMedia>(result, Messages.SocialMediaFetchedById);
        }

        public async Task<IResult> UpdateAsync(SocialMedia entity)
        {
            await _socialMediaDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SocialMediaUpdated);
        }
    }
}
