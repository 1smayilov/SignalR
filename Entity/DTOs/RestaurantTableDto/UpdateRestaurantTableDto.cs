using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.RestaurantTableDto
{
    public class UpdateRestaurantTableDto
    {
        public int RestaurantTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
