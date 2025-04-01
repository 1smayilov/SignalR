using Core.Entities;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Entity.Concrete
    {
        public class FeatureDescription : IEntity
    {
            public int FeatureDescriptionId { get; set; } 
            public string Title { get; set; }
            public string Description { get; set; }
            public int FeatureId { get; set; }
            public Feature Feature { get; set; }
        }

    }
