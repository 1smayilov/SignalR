using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using Entity.DTOs.FeatureDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        Task<IDataResult<List<ResultFeatureDto>>> GetFeatureDetailsAsync();
    }
}
