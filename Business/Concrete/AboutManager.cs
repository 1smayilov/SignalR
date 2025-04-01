using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<IResult> AddAsync(About entity)
        {
            await _aboutDal.AddAsync(entity);
            return new SuccessResult(Messages.AboutAdded);
        }

        public async Task<IResult> DeleteAsync(About entity)
        {
            await _aboutDal.DeleteAsync(entity);
            return new SuccessResult(Messages.AboutRemoved);
        }

        public async Task<IDataResult<List<About>>> GetAllAsync()
        {
             var result = await _aboutDal.GetAllAsync();
            return new SuccessDataResult<List<About>>(result, Messages.AboutsListed);
        }

        public async Task<IDataResult<About>> GetByIdAsync(int id)
        {
            var result = await _aboutDal.GetAsync(a => a.AboutId == id);
            if(result != null)
            return new SuccessDataResult<About>(result, Messages.AboutFetchedById);
            return new ErrorDataResult<About>(result, "İstifadəçi tapılmadı");
        }

        public async Task<IResult> UpdateAsync(About entity)
        {
            await _aboutDal.UpdateAsync(entity);
            return new SuccessResult(Messages.AboutUpdated);
        }
    }
}
