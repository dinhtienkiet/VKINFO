using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.BookCategoryList.Queries.GetBookCategoryList
{
    public class CategoryListViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public Category Category { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<BookCategory> TotalBook { get; set; }
    }
}
