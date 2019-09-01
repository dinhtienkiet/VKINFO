using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.GenreList.Queries.GetGenreList
{
    public class GenreListViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public Genre Genre { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public IList<BookGenre> TotalBook { get; set; }
    }
}
