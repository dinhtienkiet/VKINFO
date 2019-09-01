using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.AuthorUI.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<AuthorListViewModel>
    {
        public int Id { get; set; }
        public int CurrentPage { get; set; }
    }
}
