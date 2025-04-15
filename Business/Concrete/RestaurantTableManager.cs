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
    public class RestaurantTableManager : IRestaurantTableService
    {
        private readonly IRestaurantTableDal _restaurantTableDal;

        public RestaurantTableManager(IRestaurantTableDal restaurantTableDal)
        {
            _restaurantTableDal = restaurantTableDal;
        }

        public async Task<IResult> AddAsync(RestaurantTable entity)
        {
            await _restaurantTableDal.AddAsync(entity);
            return new SuccessResult(Messages.RestaurantTableAdded);
        }

        public async Task<IResult> DeleteAsync(RestaurantTable entity)
        {
            await _restaurantTableDal.DeleteAsync(entity);
            return new SuccessResult(Messages.RestaurantTableRemoved);
        }

        public async Task<IDataResult<List<RestaurantTable>>> GetAllAsync()
        {
            var result = await _restaurantTableDal.GetAllAsync();
            return new SuccessDataResult<List<RestaurantTable>>(result, Messages.RestaurantTablesListed);
        }

        public async Task<IDataResult<RestaurantTable>> GetByIdAsync(int id)
        {
            var result = await _restaurantTableDal.GetAsync(a => a.RestaurantTableId == id);
            return new SuccessDataResult<RestaurantTable>(result, Messages.RestaurantTableFetchedById);
        }

        public async Task<IDataResult<int>> RestaurantTableCountAsync()
        {
            return new SuccessDataResult<int>(await _restaurantTableDal.RestaurantTableCountAsync(), Messages.RestaurantTableCountFetched);
        }

        public async Task<IResult> UpdateAsync(RestaurantTable entity)
        {
            await _restaurantTableDal.UpdateAsync(entity);
            return new SuccessResult(Messages.RestaurantTableUpdated);
        }
    }
}
