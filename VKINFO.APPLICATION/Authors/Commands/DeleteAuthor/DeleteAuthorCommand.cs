using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<Object>
    {
        public int Id { get; set; }
    }
}
