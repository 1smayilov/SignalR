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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.OrderDetailId);

            builder.HasOne(od=>od.Order)
                .WithMany(o=>o.OrderDetails)
                .HasForeignKey(od=>od.OrderId)
                .IsRequired();

            builder.HasOne(od=>od.Product)
                .WithMany(p=>p.OrderDetails)
                .HasForeignKey(od=> od.ProductId)
                .IsRequired();
        }
    }
}
