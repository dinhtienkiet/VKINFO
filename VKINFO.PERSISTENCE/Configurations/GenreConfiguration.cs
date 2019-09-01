using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.PERSISTENCE.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    { 
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre_mst");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.Property(x => x.DateCreated).HasColumnName(@"DateCreated").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
            builder.Property(x => x.DateModified).HasColumnName(@"DateModified").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
        }
    }
}
