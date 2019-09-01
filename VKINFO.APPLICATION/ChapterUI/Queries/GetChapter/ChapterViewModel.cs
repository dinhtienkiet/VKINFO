using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.ChapterUI.Queries.GetChapter
{
    public class ChapterViewModel
    {
        public int Id { get; set; } // Id (Primary key)
        public int Previous { get; set; } // previous chapter id
        public int Next { get; set; } // next chapter id
        public string Title { get; set; } // Title (length: 100)
        public string Description { get; set; } // Description (length: 200)
        public string Content { get; set; } // Content (length: 1073741823)
        public int? BookId { get; set; } // BookId
        public int Status { get; set; } // Status
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime DateModified { get; set; } // DateModified

        public Book Book { get; set; } // FK__Chapter__BookId__5070F446
    }
}
