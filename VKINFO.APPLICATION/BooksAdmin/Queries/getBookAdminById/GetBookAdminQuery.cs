using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.BooksAdmin.Queries.getBookAdminById
{
    public class GetBookAdminQuery :IRequest<BookAminViewModelById>
    {
        public int Id { get; set;}
        public int CurrentPage { get; set; }
    }
}
