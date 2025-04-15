using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class FeatureDetail : IEntity
    {
        public int FeatureDetailId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FeatureId { get; set; } = 1;
        public Feature Feature { get; set; }
    }

}
