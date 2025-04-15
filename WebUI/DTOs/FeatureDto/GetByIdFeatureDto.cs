using Core.Entities;
using Entity.Concrete;
using Entity.DTOs.FeatureDetailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.DTOs.FeatureDto
{
    public class GetByIdFeatureDto 
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }

        public List<GetByIdFeatureDetailDto> FeatureDetails { get; set; }

        
    }
}
