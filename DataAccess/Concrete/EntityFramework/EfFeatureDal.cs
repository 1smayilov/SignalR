using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Migrations;
using Entity.Concrete;
using Entity.DTOs.FeatureDetailDto;
using Entity.DTOs.FeatureDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFeatureDal : EfEntityRepositoryBase<Feature, SignalRContext>, IFeatureDal
    {
        public async Task<List<ResultFeatureDto>> GetFeatureDetailsAsync()
        {
            using(var context = new SignalRContext())
            {
                var result = await context.Features.Include(f => f.FeatureDetails)
                    .Select(f => new ResultFeatureDto
                    {
                        FeatureId = f.FeatureId,
                        Name = f.Name,
                        FeatureDetails = f.FeatureDetails.Select(fd => new ResultFeatureDetailDto
                        {
                            Description = fd.Description,
                            FeatureDetailId = fd.FeatureDetailId,
                            Title = fd.Title
                        }).ToList()
                    }).ToListAsync();
                return result;
            }
        }
    }
}
