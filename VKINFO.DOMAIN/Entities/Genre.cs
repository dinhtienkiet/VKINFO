using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.DOMAIN.Entities
{
    public class Genre
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 100)
        public string Description { get; set; } // Description (length: 200)
        public int Status { get; set; } // Status
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime DateModified { get; set; } // DateModified

        public virtual ICollection<BookGenre> BookGenres { get; set; } // Many to many mapping

        public Genre()
        {
            Status = 1;
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
            BookGenres = new HashSet<BookGenre>();
        }
    }
}
