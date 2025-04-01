﻿using Core.Entities;
using Entity.DTOs.FeatureDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.FeatureDescriptionDto
{
    public class ResultFeatureDescriptionDto : IDto
    {
        public int FeatureDescriptionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FeatureId { get; set; }
        public ResultFeatureDto Feature { get; set; }
    }
}
