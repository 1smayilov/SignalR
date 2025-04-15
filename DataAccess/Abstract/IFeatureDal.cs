using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs.FeatureDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFeatureDal : IEntityRepository<Feature>
    {
        Task<List<ResultFeatureDto>> GetFeatureDetailsAsync();
    }
}
