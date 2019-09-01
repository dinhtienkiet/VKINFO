using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.CategoryAdmin.Commands.UpdateCategory
{
    public class UpdateCategoryAdminCommand : IRequest<object>
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
