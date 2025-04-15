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
    public class FeatureDetailConfiguration : IEntityTypeConfiguration<FeatureDetail>
    {
        public void Configure(EntityTypeBuilder<FeatureDetail> builder)
        {
            builder.HasKey(fd => fd.FeatureDetailId);
            builder.HasOne(fd=>fd.Feature)
                .WithMany(f => f.FeatureDetails)
                .HasForeignKey(f => f.FeatureId)
                .IsRequired();
        }
    }
}
