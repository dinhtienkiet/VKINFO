using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.DOMAIN.Entities
{
    public class Chapter
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title (length: 100)
        public string Description { get; set; } // Description (length: 200)
        public string Content { get; set; } // Content (length: 1073741823)
        public int? BookId { get; set; } // BookId
        public int Status { get; set; } // Status
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime DateModified { get; set; } // DateModified

        public virtual Book Book { get; set; } // FK__Chapter__BookId__5070F446

        public Chapter()
        {
            Status = 1;
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }
    }
}
