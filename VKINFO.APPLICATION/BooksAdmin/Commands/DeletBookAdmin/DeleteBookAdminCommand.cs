using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.BooksAdmin.Commands.DeletBookAdmin
{
    public class DeleteBookAdminCommand : IRequest<object>
    {
        public int Id { get; set; }
    }
}
