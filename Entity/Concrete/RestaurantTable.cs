using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class RestaurantTable : IEntity
    {
        public int RestaurantTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
