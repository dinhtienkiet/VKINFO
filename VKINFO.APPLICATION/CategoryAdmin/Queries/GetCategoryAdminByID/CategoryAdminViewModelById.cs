using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.CategoryAdmin.Queries.GetCategoryAdminByID
{
    public class CategoryAdminViewModelById
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }       
        public CategoryAdminViewModelById()
        {
            CurrentPage = 0;
        }
    }
}
