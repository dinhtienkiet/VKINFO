using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.DOMAIN.Entities
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
    }
}
