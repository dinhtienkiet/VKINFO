using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.HomeUI.Queries.Home
{
    public class HomeViewModel
    {
        public int PreviousPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int NextPage { get; set; }
        public IList<Book> Books { get; set; }
        public IList<Author> Authors { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<Book> HotBooks { get; set; }
        public IList<Book> GoodBooks { get; set; }
        public IList<Book> HomeBooks { get; set; }
    }
}
