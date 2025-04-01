using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task<IResult> AddAsync(Booking entity)
        {
            await _bookingDal.AddAsync(entity);
            return new SuccessResult(Messages.BookingAdded);
        }

        public async Task<IResult> DeleteAsync(Booking entity)
        {
            await _bookingDal.DeleteAsync(entity);
            return new SuccessResult(Messages.BookingRemoved);
        }

        public async Task<IDataResult<List<Booking>>> GetAllAsync() 
        {
            var result = await _bookingDal.GetAllAsync();
            return new SuccessDataResult<List<Booking>>(result, Messages.BookingsListed);
        }

        public async Task<IDataResult<Booking>> GetByIdAsync(int id)
        {
            var result = await _bookingDal.GetAsync(a => a.BookingId == id);
            return new SuccessDataResult<Booking>(result, Messages.BookingFetchedById);
        }

        public async Task<IResult> UpdateAsync(Booking entity)
        {
            await _bookingDal.UpdateAsync(entity);
            return new SuccessResult(Messages.BookingUpdated);
        }
    }
}
