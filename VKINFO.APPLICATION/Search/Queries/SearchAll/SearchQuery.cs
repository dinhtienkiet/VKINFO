using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace VKINFO.APPLICATION.Search.Queries.SearchAll
{
    public class SearchQuery : IRequest<SearchViewModel>
    {
        public string Text { get; set; }
    }
}
