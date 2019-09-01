using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.Authors.Queries.GetAuthor
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }
        public ICollection<Book> Books { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }
}
