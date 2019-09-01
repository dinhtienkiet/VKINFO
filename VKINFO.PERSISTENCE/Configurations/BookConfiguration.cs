using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.PERSISTENCE.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book_mst");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Slug).HasColumnName(@"Slug").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(x => x.Image).HasColumnName(@"Image").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);
            builder.Property(x => x.AuthorId).HasColumnName(@"AuthorId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.Property(x => x.DateCreated).HasColumnName(@"DateCreated").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
            builder.Property(x => x.DateModified).HasColumnName(@"DateModified").HasColumnType("datetime").IsRequired().HasDefaultValueSql("now()");
                        
            builder.HasOne(a => a.Author).WithMany(b => b.Books).HasForeignKey(c => c.AuthorId).OnDelete(DeleteBehavior.Cascade); // FK__Book__AuthorId__4AB81AF0     
        }
    }    
}
