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
    internal class FeatureDescriptionConfiguration : IEntityTypeConfiguration<FeatureDescription>
    {
        public void Configure(EntityTypeBuilder<FeatureDescription> builder)
        {
            builder.HasKey(fd => fd.FeatureDescriptionId);
            builder.HasOne(fd=>fd.Feature)
                .WithMany(f => f.Descriptions)
                .HasForeignKey(f => f.FeatureId)
                .IsRequired();
        }
    }
}
