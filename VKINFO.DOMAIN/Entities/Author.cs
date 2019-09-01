using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.DOMAIN.Entities
{
    public class Author
    {
        public int Id { get; set; } // Id (Primary key)
        public string FullName { get; set; } // FullName (length: 100)
        public string Nickname { get; set; } // Nickname (length: 100)
        public string Description { get; set; } // Description (length: 1073741823)
        public int Status { get; set; } // Status
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime DateModified { get; set; } // DateModified
        public virtual ICollection<Book> Books { get; set; } // Book.FK__Book__AuthorId__4AB81AF0

        public Author()
        {
            Status = 1;
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
            Books = new HashSet<Book>();
        }
    }
}
