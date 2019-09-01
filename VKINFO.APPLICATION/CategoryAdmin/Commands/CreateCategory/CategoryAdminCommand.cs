using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.CategoryAdmin.Commands.CreateCategory
{
    public class CategoryAdminCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
        public CategoryAdminCommand()
        {
            Status = 1;
        }
    }
}
