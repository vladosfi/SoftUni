﻿namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Data.Models;

    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> toyOrder)
        {
            toyOrder.HasKey(fo => new { fo.OrderId, fo.ToyId});

            toyOrder
              .HasOne(to => to.Toy)
              .WithMany(t => t.Orders)
              .HasForeignKey(to => to.ToyId)
              .OnDelete(DeleteBehavior.Restrict);

            toyOrder
              .HasOne(to => to.Order)
              .WithMany(o => o.Toys)
              .HasForeignKey(o => o.OrderId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
