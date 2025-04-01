using Core.Entities;
using Entity.Concrete;
using Entity.DTOs.FeatureDescriptionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.FeatureDto
{
    public class GetByIdFeatureDto : IDto
    {
        public int FeatureId { get; set; }
        public List<GetByIdFeatureDescriptionDto> Descriptions { get; set; }

        
    }
}
