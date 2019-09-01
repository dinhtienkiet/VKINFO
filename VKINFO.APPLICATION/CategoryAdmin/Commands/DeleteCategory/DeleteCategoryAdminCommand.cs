using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.CategoryAdmin.Commands.DeleteCategory
{
    public class DeleteCategoryAdminCommand :IRequest<object>
    {
        public int Id { get; set; }
    }
}
