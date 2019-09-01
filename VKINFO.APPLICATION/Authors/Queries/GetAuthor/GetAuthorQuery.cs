using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<AuthorViewModel>
    {
        public int Id { get; set; }
        public int Page { get; set; }
    }
}
