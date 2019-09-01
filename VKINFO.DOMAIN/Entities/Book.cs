using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.DOMAIN.Entities
{
    public class Book
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title (length: 100)
        public string Slug { get; set; } // Title (length: 1000)
        public string Description { get; set; } // Description (length: 200)
        public string Image { get; set; } // Image (length: 500)
        public int AuthorId { get; set; } // AuthorId
        public int Status { get; set; } // Status
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime DateModified { get; set; } // DateModified

        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; } // Many to many mapping               
        public virtual ICollection<BookGenre> BookGenres { get; set; } // Many to many mapping

        public virtual Author Author { get; set; }

        public Book()
        {
            Status = 2;
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
            Chapters = new HashSet<Chapter>();
            BookCategories = new HashSet<BookCategory>();
            BookGenres = new HashSet<BookGenre>();
        }
    }
}
