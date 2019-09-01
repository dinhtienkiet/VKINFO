using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.BooksUI.Queries.GetBook
{
    public class GetBookQuery : IRequest<BookViewModel>
    {
        public int Id { get; set; }
        public int CurrentPage { get; set; }
    }
}
