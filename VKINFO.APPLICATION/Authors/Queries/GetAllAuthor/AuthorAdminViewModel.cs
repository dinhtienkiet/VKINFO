using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.Authors.Queries.GetAllAuthor
{
    public class AuthorAdminViewModel
    {     
        public int Id { get; set; }
        public string FullName { get; set; } 
        public string Nickname { get; set; } 
        public string Description { get; set; } 
        public int Status { get; set; } 
        public DateTime DateCreated { get; set; } 
        public DateTime DateModified { get; set; }
        public int numberBook { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
