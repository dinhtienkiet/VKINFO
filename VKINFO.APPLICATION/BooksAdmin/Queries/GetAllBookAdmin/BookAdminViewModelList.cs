using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin;

namespace VKINFO.APPLICATION.BooksAdmin.Queries.GetAllBookAdmin
{
    public class BookAdminViewModelList
    {
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public IList<BookAdminViewModel> bookAdminViewModels { get; set; }
    }
}
