using Core.Entities;
using Entity.Concrete;
using Entity.DTOs.FeatureDetailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.FeatureDto
{
    public class ResultFeatureDto : IDto
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public List<ResultFeatureDetailDto> FeatureDetails { get; set; }

    }
}
