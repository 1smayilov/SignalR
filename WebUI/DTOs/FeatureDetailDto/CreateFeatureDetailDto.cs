using Core.Entities;
using Entity.Concrete;
using Entity.DTOs.FeatureDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.DTOs.FeatureDetailDto
{
    public class CreateFeatureDetailDto 
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
