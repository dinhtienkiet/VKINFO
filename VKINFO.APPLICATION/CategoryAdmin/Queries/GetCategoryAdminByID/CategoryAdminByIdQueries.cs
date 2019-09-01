using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.CategoryAdmin.Queries.GetCategoryAdminByID
{
    public class CategoryAdminByIdQueries :IRequest<CategoryAdminViewModelById>
    {
        public int Id { get; set;}
        public int CurrentPage { get; set; }
    }
}
