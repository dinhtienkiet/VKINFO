using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.Interfaces
{
    public interface IVKDbContext
    {
        DbSet<Author> Authors { get; set; } // Author
        
        DbSet<Book> Books { get; set; } // Book

        DbSet<Category> Categories { get; set; } // Category

        DbSet<Chapter> Chapters { get; set; } // Chapter

        DbSet<Genre> Genres { get; set; } // Genre

        DbSet<User> Users { get; set; } // User

        DbSet<BookCategory> BookCategories { get; set; }

        DbSet<BookGenre> BookGenres { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
