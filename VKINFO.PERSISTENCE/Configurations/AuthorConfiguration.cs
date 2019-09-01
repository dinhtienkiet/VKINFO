using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.PERSISTENCE.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    { 
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("author_mst");
            builder.HasKey(x => x.Id);            
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.FullName).HasColumnName(@"FullName").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nickname).HasColumnName(@"Nickname").HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(2000)").HasMaxLength(2000);
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.Property(x => x.DateCreated).HasColumnName(@"DateCreated").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
            builder.Property(x => x.DateModified).HasColumnName(@"DateModified").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
        }
    }
}
