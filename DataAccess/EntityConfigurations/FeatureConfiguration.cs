using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(f => f.FeatureId);
            builder.HasMany(f => f.Descriptions)
                .WithOne(fd=>fd.Feature)  
                .HasForeignKey(fd=>fd.FeatureId)
                .IsRequired();
        }
    }
}
