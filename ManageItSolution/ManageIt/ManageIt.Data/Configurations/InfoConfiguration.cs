using ManageIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageIt.Data.Configurations
{
    public class InfoConfiguration : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.ToTable(nameof(Info).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.Version)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(conf => conf.Email)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
