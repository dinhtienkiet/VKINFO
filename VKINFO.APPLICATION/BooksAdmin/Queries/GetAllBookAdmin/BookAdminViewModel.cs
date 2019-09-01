using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin
{
    public class BookAdminViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string AuthorName { get; set; }
        public int ChapterNumber { get; set; }

    }

}
