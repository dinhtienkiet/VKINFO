using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VKINFO.APPLICATION.BooksAdmin.Queries.GetAllBookAdmin;

namespace VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin
{
    public class GetAllBookAdminQuery : IRequest<BookAdminViewModelList>
    {
        public int CurrentPage { get; set; }
    }
}
