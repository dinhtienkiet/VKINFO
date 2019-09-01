using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.GenreList.Queries.GetGenreList
{
    public class GetGenreListQuery : IRequest<GenreListViewModel>
    {
        public int Id { get; set; }
        public int Page { get; set; }
    }
}
