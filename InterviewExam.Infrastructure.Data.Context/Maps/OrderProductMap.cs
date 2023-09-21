using InterviewExam.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewExam.Infrastructure.Data.Context.Maps
{
    internal class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder
                .HasIndex(e => e.OrderId, "IX_OrderProducts_OrderId");

            builder
                .HasIndex(e => e.ProductId, "IX_OrderProducts_ProductId");

            builder
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
