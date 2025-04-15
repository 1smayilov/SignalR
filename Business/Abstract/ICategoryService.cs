using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public Task<IDataResult<int>> CategoryCountAsync();
        public Task<IDataResult<int>> PassiveCategoryCountAsync();
        public Task<IDataResult<int>> ActiveCategoryCountAsync();
        public Task<IDataResult<int>> ProductCountByCategoryNameQəlyanaltılarAsync();


    }
}
