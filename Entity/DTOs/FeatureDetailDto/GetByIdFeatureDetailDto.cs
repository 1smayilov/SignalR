using Core.Entities;
using Entity.DTOs.FeatureDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.FeatureDetailDto
{
    public class GetByIdFeatureDetailDto : IDto
    {
        public int FeatureDetailId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
