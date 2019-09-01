using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.PERSISTENCE.Configurations
{
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("ref_book_category");

            builder.HasKey(x => new { x.BookId, x.CategoryId });
        }
    }
}
