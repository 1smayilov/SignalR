using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Feature : IEntity
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public List<FeatureDetail> FeatureDetails { get; set; } 

    }
}
