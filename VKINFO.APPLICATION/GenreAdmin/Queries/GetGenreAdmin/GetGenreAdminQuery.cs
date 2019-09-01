using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.GenreAdmin.Queries.GetGenreAdmin
{
    public class GetGenreAdminQuery : IRequest<GenreDetailAdminViewModel>
    {
        public int Id { get; set; }
        public int Page { get; set; }
    }
}
