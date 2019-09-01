using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.PERSISTENCE.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    { 
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("chapter_mst");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(x => x.Content).HasColumnName(@"Content").HasColumnType("longtext");
            builder.Property(x => x.BookId).HasColumnName(@"BookId").HasColumnType("int");
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.Property(x => x.DateCreated).HasColumnName(@"DateCreated").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
            builder.Property(x => x.DateModified).HasColumnName(@"DateModified").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");

            builder.HasOne(a => a.Book).WithMany(b => b.Chapters).HasForeignKey(c => c.BookId).OnDelete(DeleteBehavior.Cascade); // FK__Chapter__BookId__5070F446
        }
    }
}
