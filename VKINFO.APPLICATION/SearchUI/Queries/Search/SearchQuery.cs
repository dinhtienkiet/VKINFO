using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.SearchUI.Queries.Search
{
    public class SearchQuery : IRequest<SearchViewModel>
    {
        public string Text { get; set; }
    }
}
