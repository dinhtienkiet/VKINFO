using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.CategoryAdmin.Queries.GetAllCategoryAdmin
{
    public class CategoryAdminQueries : IRequest<IList<CategoryAdminViewModel>>
    {
    }
}
