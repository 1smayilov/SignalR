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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<IResult> AddAsync(Contact entity)
        {
            await _contactDal.AddAsync(entity);
            return new SuccessResult(Messages.ContactAdded);
        }

        public async Task<IResult> DeleteAsync(Contact entity)
        {
            await _contactDal.DeleteAsync(entity);
            return new SuccessResult(Messages.ContactRemoved);
        }

        public async Task<IDataResult<List<Contact>>> GetAllAsync()
        {
            var result = await _contactDal.GetAllAsync();
            return new SuccessDataResult<List<Contact>>(result, Messages.ContactsListed);
        }

        public async Task<IDataResult<Contact>> GetByIdAsync(int id)
        {
            var result = await _contactDal.GetAsync(a => a.ContactId == id);
            return new SuccessDataResult<Contact>(result, Messages.ContactFetchedById);
        }

        public async Task<IResult> UpdateAsync(Contact entity)
        {
            await _contactDal.UpdateAsync(entity);
            return new SuccessResult(Messages.ContactUpdated);
        }
    }
}
