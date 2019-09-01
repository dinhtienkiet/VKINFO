using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.PERSISTENCE.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    { 
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user_mst");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Username).HasColumnName(@"Username").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).HasColumnName(@"Password").HasColumnType("nvarchar(64)").IsRequired().HasMaxLength(64);
            builder.Property(x => x.Role).HasColumnName(@"Role").HasColumnType("int");
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.Property(x => x.DateCreated).HasColumnName(@"DateCreated").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
            builder.Property(x => x.DateModified).HasColumnName(@"DateModified").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
        }
    }
}
