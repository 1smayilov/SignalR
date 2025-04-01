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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task<IResult> AddAsync(Testimonial entity)
        {
            await _testimonialDal.AddAsync(entity);
            return new SuccessResult(Messages.TestimonialAdded);
        }

        public async Task<IResult> DeleteAsync(Testimonial entity)
        {
            await _testimonialDal.DeleteAsync(entity);
            return new SuccessResult(Messages.TestimonialRemoved);
        }

        public async Task<IDataResult<List<Testimonial>>> GetAllAsync()
        {
            var result = await _testimonialDal.GetAllAsync();
            return new SuccessDataResult<List<Testimonial>>(result, Messages.TestimonialsListed);
        }

        public async Task<IDataResult<Testimonial>> GetByIdAsync(int id)
        {
            var result = await _testimonialDal.GetAsync(a => a.TestimonialId == id);
            return new SuccessDataResult<Testimonial>(result, Messages.TestimonialFetchedById);
        }

        public async Task<IResult> UpdateAsync(Testimonial entity)
        {
            await _testimonialDal.UpdateAsync(entity);
            return new SuccessResult(Messages.TestimonialUpdated);
        }
    }
}
