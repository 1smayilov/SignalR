﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.SocialMediaDto
{
    public class GetByIdSocialMediaDto : IDto
    {
        public int SocialMediaId { get; set; }
        public int Title { get; set; }
        public int Url { get; set; }
        public int Icon { get; set; }
    }
}
