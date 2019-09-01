using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.DOMAIN.Entities
{
    public class Category
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 100)
        public string Description { get; set; } // Description (length: 200)
        public int Status { get; set; } // Status
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime DateModified { get; set; } // DateModified
                
        public virtual ICollection<BookCategory> BookCategories { get; set; } // Many to many mapping   

        public Category()
        {
            Status = 1;
            DateCreated = DateTime.Now;
            DateModified = DateCreated;            
            BookCategories = new HashSet<BookCategory>();            
        }
    }
}
