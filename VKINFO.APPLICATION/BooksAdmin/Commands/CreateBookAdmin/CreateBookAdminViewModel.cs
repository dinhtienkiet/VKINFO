using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.APPLICATION.Authors.Queries.GetAllAuthor;
using VKINFO.APPLICATION.BooksAdmin.Queries.getBookAdminById;
using VKINFO.APPLICATION.CategoryAdmin.Queries.GetAllCategoryAdmin;
using VKINFO.APPLICATION.GenreAdmin.Queries.GetAllGenreAdmin;
using VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.BooksAdmin.Commands.CreateBookAdmin
{
    public class CreateBookAdminViewModel
    {   
        public BookAminViewModelById bookDto { get; set;}
        public IList<CategoryAdminViewModel> categoryAdminViewModelList { get; set; }
        public IList<AuthorAdminViewModel> authorAdminViewModels { get; set; }
        public IList<GenreAdminViewModel> genreAdminViewModels { get; set; }

    }
   
}
