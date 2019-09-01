using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.BookCategoryList.Queries.GetBookCategoryList
{
    public class GetCategoryListQuery : IRequest<CategoryListViewModel>
    {
        public int Id { get; set; }
        public int Page { get; set; }
    }
}
