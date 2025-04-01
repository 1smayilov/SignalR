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
    public class OpeningHourManager : IOpeningHourService
    {
        private readonly IOpeningHoursDal _openingHoursDal;

        public OpeningHourManager(IOpeningHoursDal openingHoursDal)
        {
            _openingHoursDal = openingHoursDal;
        }

        public async Task<IResult> AddAsync(OpeningHours entity)
        {
            await _openingHoursDal.AddAsync(entity);
            return new SuccessResult(Messages.OpeningHourAdded);
        }

        public async Task<IResult> DeleteAsync(OpeningHours entity)
        {
            await _openingHoursDal.DeleteAsync(entity);
            return new SuccessResult(Messages.OpeningHourRemoved);
        }

        public async Task<IDataResult<List<OpeningHours>>> GetAllAsync()
        {
            var result = await _openingHoursDal.GetAllAsync();
            return new SuccessDataResult<List<OpeningHours>>(result, Messages.OpeningHoursListed);
        }

        public async Task<IDataResult<OpeningHours>> GetByIdAsync(int id)
        {
            var result = await _openingHoursDal.GetAsync(a => a.OpeningHoursId == id);
            return new SuccessDataResult<OpeningHours>(result, Messages.OpeningHourFetchedById);
        }

        public async Task<IResult> UpdateAsync(OpeningHours entity)
        {
            await _openingHoursDal.UpdateAsync(entity);
            return new SuccessResult(Messages.OpeningHourUpdated);
        }
    }
}
