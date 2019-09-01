using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.SearchUI.Queries.Search
{
    public class SearchViewModel
    {
        public ICollection<Book> Books { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
    }
}
