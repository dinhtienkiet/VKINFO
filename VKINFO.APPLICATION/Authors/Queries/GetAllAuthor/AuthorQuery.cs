using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VKINFO.APPLICATION.Authors.Commands;
using VKINFO.APPLICATION.Authors.Queries.GetAllAuthor;

namespace VKINFO.APPLICATION.Authors.Queries.GetAllAuthor
{
    public class AuthorQuery : IRequest<IList<AuthorAdminViewModel>>
    {
    }
}
