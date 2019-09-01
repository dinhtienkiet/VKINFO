using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.GenreAdmin.Queries.GetAllGenreAdmin
{
    public class GenreAdminQuery : IRequest<IList<GenreAdminViewModel>>
    {
    }
}
