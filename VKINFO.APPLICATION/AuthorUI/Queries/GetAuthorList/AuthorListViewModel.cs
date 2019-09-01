using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.AuthorUI.Queries.GetAuthorList
{
    public class AuthorListViewModel
    {
        public Author Author { get; set; }
        public ICollection<Book> Books { get; set; } // Book.
        public IList<Author> AuthorList { get; set; }
        public int CurrentPage { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public int TotalPage { get; set; }
        public AuthorListViewModel()
        {
            CurrentPage = 0;
        }
    }
}
