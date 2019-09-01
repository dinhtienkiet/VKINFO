using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin
{
    public class ChapterAdminByIdBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int BookId { get; set; }
        public int Status { get; set; }
        public int StatusBook { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
