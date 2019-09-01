using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.BooksUI.Queries.GetBook
{
    public class BookViewModel
    {
        public int NextChapterPage { get; set; }
        public int PreviousChapterPage { get; set; }
        public int CurrentChapterPage { get; set; }
        public int TotalChapterPage { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public IList<Chapter> Chapters { get; set; }
        public IList<Book> RelatedBooks { get; set; }
        public BookViewModel()
        {
            CurrentChapterPage = 0;
        }
    }
}
