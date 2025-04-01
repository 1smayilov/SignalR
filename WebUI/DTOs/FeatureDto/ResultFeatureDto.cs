using Core.Entities;
using Entity.Concrete;
using Entity.DTOs.FeatureDescriptionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.DTOs.FeatureDto
{
    public class ResultFeatureDto 
    {
        public int FeatureId { get; set; }
        public List<ResultFeatureDescriptionDto> Descriptions { get; set; }

    }
}
