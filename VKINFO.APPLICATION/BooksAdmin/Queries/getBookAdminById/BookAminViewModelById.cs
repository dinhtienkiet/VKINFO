using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin;

namespace VKINFO.APPLICATION.BooksAdmin.Queries.getBookAdminById
{
    public class BookAminViewModelById
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public int AuthorId { get; set; }
        public List<int> CategoriesID { get; set; }
        public List<int> GenreID { get; set; }
        public List<ChapterAdminByIdBookViewModel> chapterAdminByIdBookViewModels { get; set; }
        public int NextChapterPage { get; set; }
        public int PreviousChapterPage { get; set; }
        public int CurrentChapterPage { get; set; }
        public int TotalChapterPage { get; set; }
        public BookAminViewModelById()
        {
            CurrentChapterPage = 0;
        }
    }
}
