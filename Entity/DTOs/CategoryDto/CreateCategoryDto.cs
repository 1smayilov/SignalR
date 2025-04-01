using Core.Entities;
using Entity.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.CategoryDto
{
    public class CreateCategoryDto : IDto
    {
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        
    }
}
