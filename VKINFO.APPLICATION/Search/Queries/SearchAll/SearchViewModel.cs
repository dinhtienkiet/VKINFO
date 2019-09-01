using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.Search.Queries.SearchAll
{
    public class SearchViewModel
    {
        public ICollection<Book> Book { get; set; }
        public ICollection<Genre> Genre { get; set; }
        public ICollection<Category> Category { get; set; }
        public ICollection<Author> Author { get; set; }
        public ICollection<Chapter> Chapter { get; set; }
    }
}
