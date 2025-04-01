using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<TEntity>  where TEntity : class, new()
    {
        Task<IDataResult<List<TEntity>>> GetAllAsync();
        Task<IDataResult<TEntity>> GetByIdAsync(int id);
        Task<IResult> AddAsync(TEntity entity);
        Task<IResult> UpdateAsync(TEntity entity);
        Task<IResult> DeleteAsync(TEntity entity);
    }
}
