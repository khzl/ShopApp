using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Infrastructure.Persistence.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<Entity_RefreshToken>
    {

        public void Configure(EntityTypeBuilder<Entity_RefreshToken> builder)
        {

            builder.ToTable("RefreshTokens");

            builder.HasKey(rt => rt.TokenId);

            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne<Entity_Customer>()
                .WithMany()
                .HasForeignKey(rt => rt.CustomerId);
        }
    }
}
